using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Work : Interactable {

  [SerializeField] private int moneyReward = 10;
  [SerializeField] private GameMenu gameMenu;

  public override void Interact() {
    base.Interact();
    AudioManager.instance.PlaySound(AudioManager.instance.effectList[1]);
    gameMenu.UpdateMoney(moneyReward);
  }
}
