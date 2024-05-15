using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;



public class GenericInventoryManager : MonoBehaviour {
  public GameObject inventorySlotPrefab;
  public Transform contentParent; // Parent transform for the inventory slots
  public TMP_Text selectedItemNameText; // UI text to display selected item name
  [SerializeField] protected List<Outfit> initialOutfits = new List<Outfit>();
  [SerializeField] protected GameMenu gameMenu;

  protected Inventory inventory;
  [HideInInspector]public GameObject selectedSlot;

  protected void OnEnable() {
    selectedItemNameText.text = "Selected:\nNone";
    selectedSlot = null;
  }

  protected void Start() {
    // Initialize the inventory
    inventory = new Inventory();
    AddInitialItems();
    UpdateInventoryUI();
  }
  protected void AddInitialItems() {
    foreach(Outfit item in initialOutfits) {
      item.bought = false;
      inventory.AddOutfit(item);
    }
  }

  // Add a new item to the inventory
  public virtual void AddNewItem(Outfit newItem) {
    inventory.AddOutfit(newItem);
    UpdateInventoryUI();
  }

  // Remove an item from the inventory
  public virtual void RemoveItem(Outfit item) {
    inventory.RemoveOutfit(item);
    UpdateInventoryUI();
  }

  protected virtual void UpdateInventoryUI() {
    // Clear existing inventory slots
    foreach(Transform child in contentParent) {
      Destroy(child.gameObject);
    }

    // Instantiate new inventory slots for each item in the inventory
    foreach(Outfit item in inventory.outfits) {
      GameObject slot = Instantiate(inventorySlotPrefab,contentParent);
      InventorySlot inventorySlot = slot.GetComponent<InventorySlot>();
      inventorySlot.SetItem(item);
      slot.gameObject.name = item.outfitName;
      slot.GetComponent<Button>().onClick.AddListener(inventorySlot.OnClick); // Add listener for item selection
      inventorySlot.onItemClick.AddListener(SelectItem); // Subscribe to item click event
    }
  }

  // Select an item when clicked
  protected virtual void SelectItem(Outfit selectedItem) {
    Debug.Log("Selected item: " + selectedItem.outfitName);
    selectedItemNameText.text = "Selected:\n" + selectedItem.outfitName;
    selectedSlot = contentParent.Find(selectedItem.outfitName).gameObject;
  }
}
