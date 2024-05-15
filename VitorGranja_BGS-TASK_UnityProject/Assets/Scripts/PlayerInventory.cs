using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : GenericInventoryManager {
  public OutfitManager outfitManager;

  // Tells OutfitManager to equip an item
  public void EquipItem() {
    if(selectedSlot != null) {
      Outfit selectedItem = selectedSlot.GetComponent<InventorySlot>().item;
      outfitManager.EquipOutfit(selectedItem);
    }
  }

  // Tells OutfitManager to unequip an item
  public void UnequipItem() {
    if(selectedSlot != null) {
      Outfit selectedItem = selectedSlot.GetComponent<InventorySlot>().item;
      outfitManager.UnequipOutfit(selectedItem);
    }
  }
}
