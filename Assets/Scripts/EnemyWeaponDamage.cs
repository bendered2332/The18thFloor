using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponDamage : MonoBehaviour
{

  [SerializeField] int WeaponDamage = 1;
  [SerializeField] Animator HurtAnim;
  [SerializeField] AudioSource MyPlayer;
  private bool HitActive = false;

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      if (HitActive == false)
      {
        HitActive = true;
        HurtAnim.SetTrigger("Hurt");
        SaveScript.PlayerHealth -= WeaponDamage;
        SaveScript.HealthChanged = true;
        MyPlayer.Play();
      }
    }
  }

  private void OnTriggerExit(Collider other)
  {
    if (other.gameObject.CompareTag("Player"))
    {
      if (HitActive == true)
      {
        HitActive = false;

      }
    }
  }
}