using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{
  RaycastHit hit;
  [SerializeField] float Distance = 1.0f;
  [SerializeField] GameObject PickupMessage;
  private AudioSource MyPlayer;

  private float RayDistance;
  private bool CanSeePickup = false;

  // Start is called before the first frame update
  void Start()
  {
    PickupMessage.gameObject.SetActive(false);
    RayDistance = Distance;
    MyPlayer = GetComponent<AudioSource>();
  }

  // Update is called once per frame
  void Update()
  {
    if (Physics.Raycast(transform.position, transform.forward, out hit, RayDistance))
    {
      if (hit.transform.tag == "Apple")
      {
        CanSeePickup = true;
        if (Input.GetKeyDown(KeyCode.E))
        {
          if (SaveScript.Apples < 6)
          {
            Destroy(hit.transform.gameObject);
            SaveScript.Apples += 1;
            MyPlayer.Play();
          }
        }
      }
      else if (hit.transform.tag == "Battery")
      {
        CanSeePickup = true;
        if (Input.GetKeyDown(KeyCode.E))
        {
          if (SaveScript.Batteries < 4)
          {
            Destroy(hit.transform.gameObject);
            SaveScript.Batteries += 1;
            MyPlayer.Play();
          }
        }
      }
      else
      {
        CanSeePickup = false;
      }
    }
    if (CanSeePickup == true)
    {
      PickupMessage.gameObject.SetActive(true);
      RayDistance = 1000f;
    }
    if (CanSeePickup == false)
    {
      PickupMessage.gameObject.SetActive(false);
      RayDistance = Distance;
    }
  }
}
