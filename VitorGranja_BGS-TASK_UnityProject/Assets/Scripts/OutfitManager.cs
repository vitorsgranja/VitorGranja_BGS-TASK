using UnityEngine;

public class OutfitManager : MonoBehaviour {
  [SerializeField] private PlayerMovement playerMovement;

  [HideInInspector]public GameObject equipedHat;
  [HideInInspector]public GameObject equipedClothes;

  public void EquipOutfit(Outfit outfit) {
    AudioManager.instance.PlaySound(AudioManager.instance.effectList[2]);
    switch(outfit.outfitType) {
      case OutfitType.Clothes:
        equipedClothes = outfit.outFitAnimation;
        playerMovement.clothesAnim.gameObject.SetActive(true);
        playerMovement.clothesAnim.runtimeAnimatorController = outfit.outFitAnimation.GetComponent<Animator>().runtimeAnimatorController;
        break;
      case OutfitType.Hat:
        equipedHat = outfit.outFitAnimation;
        playerMovement.hatAnim.gameObject.SetActive(true);
        playerMovement.hatAnim.runtimeAnimatorController = outfit.outFitAnimation.GetComponent<Animator>().runtimeAnimatorController;
        break;
    }
    NormalizeAnimations();
  }

  public void UnequipOutfit(Outfit outfit) {
    AudioManager.instance.PlaySound(AudioManager.instance.effectList[2]);
    switch(outfit.outfitType) {
      case OutfitType.Clothes:
        equipedClothes = null;
        playerMovement.clothesAnim.gameObject.SetActive(false);
        break;
      case OutfitType.Hat:
        equipedHat = null;
        playerMovement.hatAnim.gameObject.SetActive(false);
        break;
    }
  }

  // Force animations to stay synchronized
  private void NormalizeAnimations() {
    playerMovement.baseAnim.SetTrigger("Down");
    playerMovement.underwearAnim.SetTrigger("Down");
    playerMovement.clothesAnim.SetTrigger("Down");
    playerMovement.hatAnim.SetTrigger("Down");
  }
}
