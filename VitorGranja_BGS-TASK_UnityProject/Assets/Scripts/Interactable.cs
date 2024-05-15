using UnityEngine;

public class Interactable : MonoBehaviour {

  [SerializeField] private GameObject interactionText;
  [HideInInspector] public bool interactionEnabled = false;


  private void Update() {
    if(Input.GetButtonDown("Interact") && interactionEnabled) {
      Interact();
    }
  }

  public virtual void EnableInteraction(bool canInteract) {
    if(canInteract) {
      interactionText.SetActive(true);
      interactionEnabled = true;
    } else {
      interactionText.SetActive(false);
      interactionEnabled = false;
    }
  }

  public virtual void Interact() {
    Debug.Log("Interacting with " + gameObject.name);
  }

  public virtual void OnTriggerEnter2D(Collider2D other) {
    EnableInteraction(true);
  }

  public virtual void OnTriggerExit2D(Collider2D other) {
    EnableInteraction(false);
  }
}