using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : Interactable {

  [SerializeField] private GameMenu gameMenu;
  [SerializeField] private GameObject shopUI;

  public override void Interact() {
    base.Interact();
    AudioManager.instance.PlaySound(AudioManager.instance.effectList[0]);
    gameMenu.ActivateShop();
    EnableInteraction(false);
  }
  public override void OnTriggerExit2D(Collider2D other) {
    base.OnTriggerExit2D(other);
    if(shopUI.activeInHierarchy) {
      gameMenu.ActivateShop();
    }
  }
}