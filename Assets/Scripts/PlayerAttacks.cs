using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
  private Animator Anim;
  // Start is called before the first frame update
  void Start()
  {
    Anim = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update()
  {
    if (SaveScript.HaveKnife == true)
    {
      if (Input.GetKeyDown(KeyCode.Mouse0))
      {
        Anim.SetTrigger("KnifeLMB");
      }
      if (Input.GetKeyDown(KeyCode.Mouse1))
      {
        Anim.SetTrigger("KnifeRMB");
      }
    }
    if (SaveScript.HaveBat == true)
    {
      if (Input.GetKeyDown(KeyCode.Mouse0))
      {
        Anim.SetTrigger("BatLMB");
      }
      if (Input.GetKeyDown(KeyCode.Mouse1))
      {
        Anim.SetTrigger("BatRMB");
      }
    }
    if (SaveScript.HaveAxe == true)
    {
      if (Input.GetKeyDown(KeyCode.Mouse0))
      {
        Anim.SetTrigger("AxeLMB");
      }
      if (Input.GetKeyDown(KeyCode.Mouse1))
      {
        Anim.SetTrigger("AxeRMB");
      }
    }
  }
}
