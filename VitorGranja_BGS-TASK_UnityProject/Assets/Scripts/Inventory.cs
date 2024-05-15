using System.Collections.Generic;

public class Inventory {
  public List<Outfit> outfits = new List<Outfit>();

  public void AddOutfit(Outfit outfit) {
    outfits.Add(outfit);
  }

  public void RemoveOutfit(Outfit outfit) {
    outfits.Remove(outfit);
  }
}
