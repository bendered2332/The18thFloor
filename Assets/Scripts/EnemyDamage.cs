using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
  public int EnemyHealth = 100;
  private AudioSource MyPlayer;
  [SerializeField] AudioSource StabPlayer;
  private Animator Anim;
  private bool HasDied = false;

  // Start is called before the first frame update
  void Start()
  {
    MyPlayer = GetComponent<AudioSource>();
    Anim = GetComponentInParent<Animator>();
  }

  // Update is called once per frame
  void Update()
  {
    if (EnemyHealth <= 0)
    {
      if (HasDied == false)
      {
        Anim.SetTrigger("Death");
        HasDied = true;
      }
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.CompareTag("PKnife"))
    {
      EnemyHealth -= 10;
      MyPlayer.Play();
      StabPlayer.Play();
    }
    if (other.gameObject.CompareTag("PBat"))
    {
      EnemyHealth -= 15;
      MyPlayer.Play();
    }
    if (other.gameObject.CompareTag("PAxe"))
    {
      EnemyHealth -= 20;
      MyPlayer.Play();
      StabPlayer.Play();
    }
  }
}
