using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

  [SerializeField] GameObject InventoryMenu;
  private bool InventoryActive = false;
  private AudioSource MyPlayer;
  [SerializeField] AudioClip AppleBite;
  [SerializeField] AudioClip BatteryChange;
  [SerializeField] AudioClip WeaponChange;
  [SerializeField] AudioClip GunShot;
  [SerializeField] AudioClip ArrowShot;
  [SerializeField] GameObject PlayerArms;
  [SerializeField] GameObject Knife;
  [SerializeField] GameObject Bat;
  [SerializeField] GameObject Axe;
  [SerializeField] GameObject Gun;
  [SerializeField] GameObject Crossbow;


  [SerializeField] Animator Anim;



  //Apples
  [SerializeField] GameObject AppleImage1;
  [SerializeField] GameObject AppleButton1;
  [SerializeField] GameObject AppleImage2;
  [SerializeField] GameObject AppleButton2;
  [SerializeField] GameObject AppleImage3;
  [SerializeField] GameObject AppleButton3;
  [SerializeField] GameObject AppleImage4;
  [SerializeField] GameObject AppleButton4;
  [SerializeField] GameObject AppleImage5;
  [SerializeField] GameObject AppleButton5;
  [SerializeField] GameObject AppleImage6;
  [SerializeField] GameObject AppleButton6;

  //Batteries
  [SerializeField] GameObject BatteryImage1;
  [SerializeField] GameObject BatteryButton1;
  [SerializeField] GameObject BatteryImage2;
  [SerializeField] GameObject BatteryButton2;
  [SerializeField] GameObject BatteryImage3;
  [SerializeField] GameObject BatteryButton3;
  [SerializeField] GameObject BatteryImage4;
  [SerializeField] GameObject BatteryButton4;

  //Weapons
  [SerializeField] GameObject KnifeImage;
  [SerializeField] GameObject KnifeButton;
  [SerializeField] GameObject BatImage;
  [SerializeField] GameObject BatButton;
  [SerializeField] GameObject AxeImage;
  [SerializeField] GameObject AxeButton;
  [SerializeField] GameObject GunImage;
  [SerializeField] GameObject GunButton;
  [SerializeField] GameObject CrossbowImage;
  [SerializeField] GameObject CrossbowButton;

  //Ammo
  [SerializeField] GameObject MagazineIcon1;
  [SerializeField] GameObject MagazineButton1;
  [SerializeField] GameObject MagazineIcon2;
  [SerializeField] GameObject MagazineButton2;
  [SerializeField] GameObject MagazineIcon3;
  [SerializeField] GameObject MagazineButton3;
  [SerializeField] GameObject MagazineIcon4;
  [SerializeField] GameObject MagazineButton4;
  [SerializeField] GameObject CrossbowBoltsIcon;
  [SerializeField] GameObject CrossbowBoltsButton;

  //Key
  [SerializeField] GameObject RoomKeyIcon;

  // Start is called before the first frame update
  void Start()
  {
    InventoryMenu.gameObject.SetActive(false);
    InventoryActive = false;
    Cursor.visible = false;
    MyPlayer = GetComponent<AudioSource>();


    //Apples
    AppleImage1.gameObject.SetActive(false);
    AppleButton1.gameObject.SetActive(false);
    AppleImage2.gameObject.SetActive(false);
    AppleButton2.gameObject.SetActive(false);
    AppleImage3.gameObject.SetActive(false);
    AppleButton3.gameObject.SetActive(false);
    AppleImage4.gameObject.SetActive(false);
    AppleButton4.gameObject.SetActive(false);
    AppleImage5.gameObject.SetActive(false);
    AppleButton5.gameObject.SetActive(false);
    AppleImage6.gameObject.SetActive(false);
    AppleButton6.gameObject.SetActive(false);

    //Batteries
    BatteryImage1.gameObject.SetActive(false);
    BatteryButton1.gameObject.SetActive(false);
    BatteryImage2.gameObject.SetActive(false);
    BatteryButton2.gameObject.SetActive(false);
    BatteryImage3.gameObject.SetActive(false);
    BatteryButton3.gameObject.SetActive(false);
    BatteryImage4.gameObject.SetActive(false);
    BatteryButton4.gameObject.SetActive(false);

    //Weapons
    KnifeImage.gameObject.SetActive(false);
    KnifeButton.gameObject.SetActive(false);
    BatImage.gameObject.SetActive(false);
    BatButton.gameObject.SetActive(false);
    AxeImage.gameObject.SetActive(false);
    AxeButton.gameObject.SetActive(false);
    GunImage.gameObject.SetActive(false);
    GunButton.gameObject.SetActive(false);
    CrossbowImage.gameObject.SetActive(false);
    CrossbowButton.gameObject.SetActive(false);

    //Key
    RoomKeyIcon.gameObject.SetActive(false);

    //Ammo
    MagazineIcon1.gameObject.SetActive(false);
    MagazineButton1.gameObject.SetActive(false);
    MagazineIcon2.gameObject.SetActive(false);
    MagazineButton2.gameObject.SetActive(false);
    MagazineIcon3.gameObject.SetActive(false);
    MagazineButton3.gameObject.SetActive(false);
    MagazineIcon4.gameObject.SetActive(false);
    MagazineButton4.gameObject.SetActive(false);
    CrossbowBoltsIcon.gameObject.SetActive(false);
    CrossbowBoltsButton.gameObject.SetActive(false);
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
        SaveScript.HaveKnife = false;
        SaveScript.HaveBat = false;
        SaveScript.HaveAxe = false;
      }
      else if (InventoryActive == true)
      {
        InventoryMenu.gameObject.SetActive(false);
        InventoryActive = false;
        Time.timeScale = 1f;
        Cursor.visible = false;
      }
    }
    CheckInventory();
    CheckWeapons();
    CheckMagazines();
    CheckBolts();
    CheckKey();
  }

  void CheckKey()
  {
    if (SaveScript.RoomKey == true)
    {
      RoomKeyIcon.gameObject.SetActive(true);

    }
  }

  void CheckBolts()
  {
    if (SaveScript.Bolts == 0)
    {
      CrossbowBoltsIcon.gameObject.SetActive(false);
      CrossbowBoltsButton.gameObject.SetActive(false);
    }
    if (SaveScript.Bolts == 1)
    {
      CrossbowBoltsIcon.gameObject.SetActive(true);
      CrossbowBoltsButton.gameObject.SetActive(true);
    }
  }

  void CheckMagazines()
  {
    //Magazines
    if (SaveScript.Magazines == 0)
    {
      MagazineIcon1.gameObject.SetActive(false);
      MagazineButton1.gameObject.SetActive(false);
      MagazineIcon2.gameObject.SetActive(false);
      MagazineButton2.gameObject.SetActive(false);
      MagazineIcon3.gameObject.SetActive(false);
      MagazineButton3.gameObject.SetActive(false);
      MagazineIcon4.gameObject.SetActive(false);
      MagazineButton4.gameObject.SetActive(false);

    }
    if (SaveScript.Magazines == 1)
    {
      MagazineIcon1.gameObject.SetActive(true);
      MagazineButton1.gameObject.SetActive(true);
      MagazineIcon2.gameObject.SetActive(false);
      MagazineButton2.gameObject.SetActive(false);
      MagazineIcon3.gameObject.SetActive(false);
      MagazineButton3.gameObject.SetActive(false);
      MagazineIcon4.gameObject.SetActive(false);
      MagazineButton4.gameObject.SetActive(false);
    }
    if (SaveScript.Magazines == 2)
    {
      MagazineIcon1.gameObject.SetActive(true);
      MagazineButton1.gameObject.SetActive(false);
      MagazineIcon2.gameObject.SetActive(true);
      MagazineButton2.gameObject.SetActive(true);
      MagazineIcon3.gameObject.SetActive(false);
      MagazineButton3.gameObject.SetActive(false);
      MagazineIcon4.gameObject.SetActive(false);
      MagazineButton4.gameObject.SetActive(false);
    }
    if (SaveScript.Magazines == 3)
    {
      MagazineIcon1.gameObject.SetActive(true);
      MagazineButton1.gameObject.SetActive(false);
      MagazineIcon2.gameObject.SetActive(true);
      MagazineButton2.gameObject.SetActive(false);
      MagazineIcon3.gameObject.SetActive(true);
      MagazineButton3.gameObject.SetActive(true);
      MagazineIcon4.gameObject.SetActive(false);
      MagazineButton4.gameObject.SetActive(false);
    }
    if (SaveScript.Magazines == 4)
    {
      MagazineIcon1.gameObject.SetActive(true);
      MagazineButton1.gameObject.SetActive(false);
      MagazineIcon2.gameObject.SetActive(true);
      MagazineButton2.gameObject.SetActive(false);
      MagazineIcon3.gameObject.SetActive(true);
      MagazineButton3.gameObject.SetActive(false);
      MagazineIcon4.gameObject.SetActive(true);
      MagazineButton4.gameObject.SetActive(true);
    }
  }

  void CheckInventory()
  {
    //Apples
    if (SaveScript.Apples == 0)
    {
      AppleImage1.gameObject.SetActive(false);
      AppleButton1.gameObject.SetActive(false);
      AppleImage2.gameObject.SetActive(false);
      AppleButton2.gameObject.SetActive(false);
      AppleImage3.gameObject.SetActive(false);
      AppleButton3.gameObject.SetActive(false);
      AppleImage4.gameObject.SetActive(false);
      AppleButton4.gameObject.SetActive(false);
      AppleImage5.gameObject.SetActive(false);
      AppleButton5.gameObject.SetActive(false);
      AppleImage6.gameObject.SetActive(false);
      AppleButton6.gameObject.SetActive(false);
    }
    if (SaveScript.Apples == 1)
    {
      AppleImage1.gameObject.SetActive(true);
      AppleButton1.gameObject.SetActive(true);
      AppleImage2.gameObject.SetActive(false);
      AppleButton2.gameObject.SetActive(false);
      AppleImage3.gameObject.SetActive(false);
      AppleButton3.gameObject.SetActive(false);
      AppleImage4.gameObject.SetActive(false);
      AppleButton4.gameObject.SetActive(false);
      AppleImage5.gameObject.SetActive(false);
      AppleButton5.gameObject.SetActive(false);
      AppleImage6.gameObject.SetActive(false);
      AppleButton6.gameObject.SetActive(false);
    }
    if (SaveScript.Apples == 2)
    {
      AppleImage1.gameObject.SetActive(true);
      AppleButton1.gameObject.SetActive(false);
      AppleImage2.gameObject.SetActive(true);
      AppleButton2.gameObject.SetActive(true);
      AppleImage3.gameObject.SetActive(false);
      AppleButton3.gameObject.SetActive(false);
      AppleImage4.gameObject.SetActive(false);
      AppleButton4.gameObject.SetActive(false);
      AppleImage5.gameObject.SetActive(false);
      AppleButton5.gameObject.SetActive(false);
      AppleImage6.gameObject.SetActive(false);
      AppleButton6.gameObject.SetActive(false);
    }
    if (SaveScript.Apples == 3)
    {
      AppleImage1.gameObject.SetActive(true);
      AppleButton1.gameObject.SetActive(false);
      AppleImage2.gameObject.SetActive(true);
      AppleButton2.gameObject.SetActive(false);
      AppleImage3.gameObject.SetActive(true);
      AppleButton3.gameObject.SetActive(true);
      AppleImage4.gameObject.SetActive(false);
      AppleButton4.gameObject.SetActive(false);
      AppleImage5.gameObject.SetActive(false);
      AppleButton5.gameObject.SetActive(false);
      AppleImage6.gameObject.SetActive(false);
      AppleButton6.gameObject.SetActive(false);
    }
    if (SaveScript.Apples == 4)
    {
      AppleImage1.gameObject.SetActive(true);
      AppleButton1.gameObject.SetActive(false);
      AppleImage2.gameObject.SetActive(true);
      AppleButton2.gameObject.SetActive(false);
      AppleImage3.gameObject.SetActive(true);
      AppleButton3.gameObject.SetActive(false);
      AppleImage4.gameObject.SetActive(true);
      AppleButton4.gameObject.SetActive(true);
      AppleImage5.gameObject.SetActive(false);
      AppleButton5.gameObject.SetActive(false);
      AppleImage6.gameObject.SetActive(false);
      AppleButton6.gameObject.SetActive(false);
    }
    if (SaveScript.Apples == 5)
    {
      AppleImage1.gameObject.SetActive(true);
      AppleButton1.gameObject.SetActive(false);
      AppleImage2.gameObject.SetActive(true);
      AppleButton2.gameObject.SetActive(false);
      AppleImage3.gameObject.SetActive(true);
      AppleButton3.gameObject.SetActive(false);
      AppleImage4.gameObject.SetActive(true);
      AppleButton4.gameObject.SetActive(false);
      AppleImage5.gameObject.SetActive(true);
      AppleButton5.gameObject.SetActive(true);
      AppleImage6.gameObject.SetActive(false);
      AppleButton6.gameObject.SetActive(false);
    }
    if (SaveScript.Apples == 6)
    {
      AppleImage1.gameObject.SetActive(true);
      AppleButton1.gameObject.SetActive(false);
      AppleImage2.gameObject.SetActive(true);
      AppleButton2.gameObject.SetActive(false);
      AppleImage3.gameObject.SetActive(true);
      AppleButton3.gameObject.SetActive(false);
      AppleImage4.gameObject.SetActive(true);
      AppleButton4.gameObject.SetActive(false);
      AppleImage5.gameObject.SetActive(true);
      AppleButton5.gameObject.SetActive(false);
      AppleImage6.gameObject.SetActive(true);
      AppleButton6.gameObject.SetActive(true);
    }

    //Batteries
    if (SaveScript.Batteries == 0)
    {
      BatteryImage1.gameObject.SetActive(false);
      BatteryButton1.gameObject.SetActive(false);
      BatteryImage2.gameObject.SetActive(false);
      BatteryButton2.gameObject.SetActive(false);
      BatteryImage3.gameObject.SetActive(false);
      BatteryButton3.gameObject.SetActive(false);
      BatteryImage4.gameObject.SetActive(false);
      BatteryButton4.gameObject.SetActive(false);
    }
    if (SaveScript.Batteries == 1)
    {
      BatteryImage1.gameObject.SetActive(true);
      BatteryButton1.gameObject.SetActive(true);
      BatteryImage2.gameObject.SetActive(false);
      BatteryButton2.gameObject.SetActive(false);
      BatteryImage3.gameObject.SetActive(false);
      BatteryButton3.gameObject.SetActive(false);
      BatteryImage4.gameObject.SetActive(false);
      BatteryButton4.gameObject.SetActive(false);
    }
    if (SaveScript.Batteries == 2)
    {
      BatteryImage1.gameObject.SetActive(true);
      BatteryButton1.gameObject.SetActive(false);
      BatteryImage2.gameObject.SetActive(true);
      BatteryButton2.gameObject.SetActive(true);
      BatteryImage3.gameObject.SetActive(false);
      BatteryButton3.gameObject.SetActive(false);
      BatteryImage4.gameObject.SetActive(false);
      BatteryButton4.gameObject.SetActive(false);
    }
    if (SaveScript.Batteries == 3)
    {
      BatteryImage1.gameObject.SetActive(true);
      BatteryButton1.gameObject.SetActive(false);
      BatteryImage2.gameObject.SetActive(true);
      BatteryButton2.gameObject.SetActive(false);
      BatteryImage3.gameObject.SetActive(true);
      BatteryButton3.gameObject.SetActive(true);
      BatteryImage4.gameObject.SetActive(false);
      BatteryButton4.gameObject.SetActive(false);
    }
    if (SaveScript.Batteries == 4)
    {
      BatteryImage1.gameObject.SetActive(true);
      BatteryButton1.gameObject.SetActive(false);
      BatteryImage2.gameObject.SetActive(true);
      BatteryButton2.gameObject.SetActive(false);
      BatteryImage3.gameObject.SetActive(true);
      BatteryButton3.gameObject.SetActive(false);
      BatteryImage4.gameObject.SetActive(true);
      BatteryButton4.gameObject.SetActive(true);
    }
  }

  void CheckWeapons()
  {
    if (SaveScript.Knife == true)
    {
      KnifeImage.gameObject.SetActive(true);
      KnifeButton.gameObject.SetActive(true);
    }
    if (SaveScript.Bat == true)
    {
      BatImage.gameObject.SetActive(true);
      BatButton.gameObject.SetActive(true);
    }
    if (SaveScript.Axe == true)
    {
      AxeImage.gameObject.SetActive(true);
      AxeButton.gameObject.SetActive(true);
    }
    if (SaveScript.Gun == true)
    {
      GunImage.gameObject.SetActive(true);
      GunButton.gameObject.SetActive(true);
    }
    if (SaveScript.Crossbow == true)
    {
      CrossbowImage.gameObject.SetActive(true);
      CrossbowButton.gameObject.SetActive(true);
    }
  }
  public void HealthUpdate()
  {
    if (SaveScript.PlayerHealth < 100)
    {
      SaveScript.PlayerHealth += 10;
      SaveScript.HealthChanged = true;
      SaveScript.Apples -= 1;
      MyPlayer.clip = AppleBite;
      MyPlayer.Play();

      if (SaveScript.PlayerHealth > 100)
      {
        SaveScript.PlayerHealth = 100;
      }
    }
  }

  public void BatteryUpdate()
  {
    SaveScript.BatteryRefill = true;
    SaveScript.Batteries -= 1;
    MyPlayer.clip = BatteryChange;
    MyPlayer.Play();
  }

  public void AssignKnife()
  {
    PlayerArms.gameObject.SetActive(true);
    Knife.gameObject.SetActive(true);
    Anim.SetBool("Melee", true);
    MyPlayer.clip = WeaponChange;
    MyPlayer.Play();
    SaveScript.HaveKnife = true;
    SaveScript.HaveBat = false;
    SaveScript.HaveAxe = false;
  }
  public void AssignBat()
  {
    PlayerArms.gameObject.SetActive(true);
    Bat.gameObject.SetActive(true);
    Anim.SetBool("Melee", true);
    MyPlayer.clip = WeaponChange;
    MyPlayer.Play();
    SaveScript.HaveKnife = false;
    SaveScript.HaveBat = true;
    SaveScript.HaveAxe = false;
  }
  public void AssignAxe()
  {
    PlayerArms.gameObject.SetActive(true);
    Axe.gameObject.SetActive(true);
    Anim.SetBool("Melee", true);
    MyPlayer.clip = WeaponChange;
    MyPlayer.Play();
    SaveScript.HaveKnife = false;
    SaveScript.HaveBat = false;
    SaveScript.HaveAxe = true;
  }
  public void AssignGun()
  {
    PlayerArms.gameObject.SetActive(true);
    Gun.gameObject.SetActive(true);
    Anim.SetBool("Melee", false);
    MyPlayer.clip = GunShot;
    MyPlayer.Play();
  }
  public void AssignCrossbow()
  {
    PlayerArms.gameObject.SetActive(true);
    Crossbow.gameObject.SetActive(true);
    Anim.SetBool("Melee", false);
    MyPlayer.clip = ArrowShot;
    MyPlayer.Play();
  }

  public void WeaponsOff()
  {
    Axe.gameObject.SetActive(false);
    Bat.gameObject.SetActive(false);
    Knife.gameObject.SetActive(false);
    Gun.gameObject.SetActive(false);
    Crossbow.gameObject.SetActive(false);
  }
}
