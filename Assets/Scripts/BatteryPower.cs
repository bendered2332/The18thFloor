using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BatteryPower : MonoBehaviour
{
  [SerializeField] Image BatteryUI;
  [SerializeField] float DrainTime = 15.0f;
  [SerializeField] float Power;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    BatteryUI.fillAmount -= 1.0f / DrainTime * Time.deltaTime;
    Power = BatteryUI.fillAmount;
    SaveScript.BatteryPower = Power;

    Debug.Log(SaveScript.BatteryPower);
  }
}
