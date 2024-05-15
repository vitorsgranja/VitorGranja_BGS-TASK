using UnityEngine;
using UnityEditor.Animations;

[CreateAssetMenu(fileName = "New Outfit",menuName = "Outfit")]
public class Outfit : ScriptableObject {
  public string outfitName;
  public Sprite icon;
  public int price;
  public OutfitType outfitType;
  public GameObject outFitAnimation;
  public bool bought = false;
}

public enum OutfitType {
  Clothes,
  Hat
}
