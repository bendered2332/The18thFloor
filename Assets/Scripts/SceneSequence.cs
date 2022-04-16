using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSequence : MonoBehaviour
{


  public GameObject Cam1;
  public GameObject Cam2;
  public GameObject Cam3;
  public GameObject Cam4;
  public GameObject Cam5;
  public GameObject IntroDialogue;
  public GameObject Canvas;

  // Start is called before the first frame update
  void Start()
  {
    StartCoroutine(TheSequence());
    Cam5.SetActive(false);
    Canvas.SetActive(false);
    IntroDialogue.SetActive(true);
  }

  IEnumerator TheSequence()
  {
    yield return new WaitForSeconds(4);
    Cam2.SetActive(true);
    Cam1.SetActive(false);

    yield return new WaitForSeconds(4);
    Cam3.SetActive(true);
    Cam2.SetActive(false);

    yield return new WaitForSeconds(4);
    Cam4.SetActive(true);
    Cam3.SetActive(false);

    yield return new WaitForSeconds(4);
    Cam5.SetActive(true);
    Canvas.SetActive(true);
    IntroDialogue.SetActive(false);
    Cam4.SetActive(false);

  }


}
