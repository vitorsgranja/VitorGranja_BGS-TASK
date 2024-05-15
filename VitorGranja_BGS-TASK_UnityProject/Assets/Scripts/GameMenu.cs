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

  public void ReturnToMenu() {
    SceneManager.LoadScene("Menu");
  }

  private void Update() {
    if(Input.GetButtonDown("Esc")) {
      ActivateMenu();
    }
    if(Input.GetButtonDown("Inventory")) {
      ActivateInventory();
    }
  }

  private void ActivateMenu() { // close all other menus and open/close EscMenu
    shop.SetActive(false);
    inventory.SetActive(false);
    escMenu.SetActive(!escMenu.activeInHierarchy);
  }
  public void ActivateShop() {
    if(!shop.activeInHierarchy && !escMenu.activeInHierarchy) {
      shop.SetActive(true);
      inventory.SetActive(true);
    } else {
      shop.SetActive(false);
      inventory.SetActive(false);
    }
  }
  private void ActivateInventory() {
    if(!inventory.activeInHierarchy && !escMenu.activeInHierarchy) {
      inventory.SetActive(true);
    } else {
      inventory.SetActive(false);
    }
  }
  public void UpdateMoney(int change) {
    double tempMoney = GameManager.instance.AddMoney(change);
    money.text = "$" + tempMoney.ToString();
  }
}
