using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ShopInventory : GenericInventoryManager {
  [SerializeField] private PlayerInventory playerInventory;

  public void BuySelectedItem() {
    if(selectedSlot != null) {
      Outfit selectedItem = selectedSlot.GetComponent<InventorySlot>().item;
      if(selectedItem.price <= GameManager.instance.GetPlayerMoney() && selectedItem.bought == false) {
        selectedItem.bought = true;
        gameMenu.UpdateMoney(-selectedItem.price);
        RemoveItem(selectedItem);
        playerInventory.AddNewItem(selectedItem);
        selectedItemNameText.text = "Selected:\nNone";
      }
      Debug.Log("Bought " + selectedItem.outfitName);
    }
  }

  public void SellSelectedItem() {
    if(playerInventory.selectedSlot != null) {
      Outfit selectedItem = playerInventory.selectedSlot.GetComponent<InventorySlot>().item;

      selectedItem.bought = false;
      gameMenu.UpdateMoney((int)math.trunc(selectedItem.price/2));
      CheckItemOnSell(selectedItem);
      playerInventory.RemoveItem(selectedItem);
      AddNewItem(selectedItem);
      playerInventory.selectedItemNameText.text = "Selected:\nNone";

      Debug.Log("Sold " + selectedItem.outfitName);
    }
  }

  // Checks if sold item is equipped, if so, unequip it
  private void CheckItemOnSell(Outfit selectedItem) {
    if(playerInventory.outfitManager.equipedHat != null && playerInventory.outfitManager.equipedHat == selectedItem.outFitAnimation) {
      playerInventory.UnequipItem();
    }
    if(playerInventory.outfitManager.equipedClothes != null && playerInventory.outfitManager.equipedClothes == selectedItem.outFitAnimation) {
      playerInventory.UnequipItem();
    }
  }
}