using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSequence : MonoBehaviour
{


  public GameObject Cam1;
  public GameObject Player;
  public GameObject IntroDialogue;
  public GameObject Canvas;

  // Start is called before the first frame update
  void Start()
  {
    StartCoroutine(TheSequence());
    Player.SetActive(false);
    Canvas.SetActive(false);
    IntroDialogue.SetActive(true);
  }

  IEnumerator TheSequence()
  {
    yield return new WaitForSeconds(6);
    Player.SetActive(true);
    Cam1.SetActive(false);
    IntroDialogue.SetActive(false);
    Canvas.SetActive(true);
  }


}
