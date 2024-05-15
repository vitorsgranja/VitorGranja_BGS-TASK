using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour {
  public Outfit item; // Reference to the item in this slot
  public UnityEvent<Outfit> onItemClick; // Event to be invoked when the slot is clicked
  [SerializeField] private Image itemImage;
  [SerializeField] private TMP_Text itemPrice;

  // Set the item in this slot
  public void SetItem(Outfit newItem) {
    item = newItem;
    itemImage.sprite = item.icon;
    itemPrice.text = item.price.ToString();
  }

  // Handles click events on the slot
  public void OnClick() {
    onItemClick.Invoke(item);
  }
}
