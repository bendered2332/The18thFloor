using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

  [SerializeField] GameObject InventoryMenu;
  private bool InventoryActive = false;
  // Start is called before the first frame update
  void Start()
  {
    InventoryMenu.gameObject.SetActive(false);
    InventoryActive = false;
    Cursor.visible = false;
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.I))
    {
      if (InventoryActive == false)
      {
        InventoryMenu.gameObject.SetActive(true);
        InventoryActive = true;
        Time.timeScale = 0f;
        Cursor.visible = true;
      }
      else if (InventoryActive == true)
      {
        InventoryMenu.gameObject.SetActive(false);
        InventoryActive = false;
        Time.timeScale = 1f;
        Cursor.visible = false;
      }
    }
  }
}
