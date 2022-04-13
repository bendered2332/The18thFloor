using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LightSettingsPlayer : MonoBehaviour
{
  [SerializeField] PostProcessVolume MyVolume;
  [SerializeField] PostProcessProfile Standard;
  [SerializeField] PostProcessProfile NightVision;
  [SerializeField] GameObject NightVisionOverlay;
  [SerializeField] GameObject Flashlight;
  private bool NightVisionActive = false;
  private bool FlashlightActive = false;

  void Start()
  {
    NightVisionOverlay.gameObject.SetActive(false);
    Flashlight.gameObject.SetActive(false);
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.N))
    {
      if (NightVisionActive == false)
      {
        MyVolume.profile = NightVision;
        NightVisionActive = true;
        NightVisionOverlay.gameObject.SetActive(true);
      }
      else
      {
        MyVolume.profile = Standard;
        NightVisionActive = false;
        NightVisionOverlay.gameObject.SetActive(false);
      }
    }


    if (Input.GetKeyDown(KeyCode.F))
    {
      if (FlashlightActive == false)
      {

        FlashlightActive = true;
        Flashlight.gameObject.SetActive(true);
      }
      else
      {

        FlashlightActive = false;
        Flashlight.gameObject.SetActive(false);
      }
    }
  }
}
