using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSequence : MonoBehaviour
{


  public GameObject Cam1;
  public GameObject Player;

  public GameObject PlayerModel;

  public GameObject IntroDialogue;
  public GameObject Canvas;

  // Start is called before the first frame update
  void Start()
  {
    StartCoroutine(TheSequence());
    PlayerModel.SetActive(true);
    Player.SetActive(false);
    Canvas.SetActive(false);
    IntroDialogue.SetActive(true);

  }

  IEnumerator TheSequence()
  {
    yield return new WaitForSeconds(4);

    Cam1.SetActive(false);
    PlayerModel.SetActive(false);
    Player.SetActive(true);
    IntroDialogue.SetActive(false);
    Canvas.SetActive(true);
  }


}
