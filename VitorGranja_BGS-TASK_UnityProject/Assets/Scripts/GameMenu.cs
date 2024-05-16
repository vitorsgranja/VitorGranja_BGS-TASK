using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour {
  [SerializeField] private GameObject escMenu;
  [SerializeField] private GameObject inventory;
  [SerializeField] private GameObject shop;
  [SerializeField] private TMP_Text money;

  // Load the Main menu Scene
  public void ReturnToMenu() {
    SceneManager.LoadScene("MainMenu");
  }

  private void Update() {
    if(Input.GetButtonDown("Esc")) {
      ActivateMenu();
    }
    if(Input.GetButtonDown("Inventory")) {
      ActivateInventory();
    }
  }

  // close all other menus and open/close EscMenu
  private void ActivateMenu() { 
    shop.SetActive(false);
    inventory.SetActive(false);
    escMenu.SetActive(!escMenu.activeInHierarchy);
  }

  // Activate/Deactivate shop and inventory
  public void ActivateShop() {
    if(!shop.activeInHierarchy && !escMenu.activeInHierarchy) {
      shop.SetActive(true);
      inventory.SetActive(true);
    } else {
      shop.SetActive(false);
      inventory.SetActive(false);
    }
  }

  // Activate/Deactivate Inventory
  private void ActivateInventory() {
    if(!inventory.activeInHierarchy && !escMenu.activeInHierarchy) {
      inventory.SetActive(true);
    } else {
      inventory.SetActive(false);
    }
  }

  // Tells the GameManager any change on Player money and updates the HUD
  public void UpdateMoney(int change) {
    double tempMoney = GameManager.instance.AddMoney(change);
    money.text = "$" + tempMoney.ToString();
  }
}