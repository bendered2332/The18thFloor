using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
  public int EnemyHealth = 100;
  private AudioSource MyPlayer;
  [SerializeField] GameObject WinScreen;
  [SerializeField] AudioSource StabPlayer;
  private Animator Anim;
  private bool HasDied = false;

  // Start is called before the first frame update
  void Start()
  {
    MyPlayer = GetComponent<AudioSource>();
    Anim = GetComponentInParent<Animator>();
    WinScreen.gameObject.SetActive(false);
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
        WinScreen.gameObject.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;

      }
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.gameObject.CompareTag("Knife"))
    {
      EnemyHealth -= 25;
      MyPlayer.Play();
      StabPlayer.Play();
    }
  }
}
