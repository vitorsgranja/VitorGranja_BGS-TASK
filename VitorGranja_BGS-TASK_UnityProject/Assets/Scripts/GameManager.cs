using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
  public static GameManager instance; // Singleton instance

  private int playerMoney = 0;
  private Text playerMoneyText;

  private void Awake() {
    // Singleton pattern to ensure only one instance of GameManager exists
    if(instance == null) {
      instance = this;
      DontDestroyOnLoad(gameObject);
    } else {
      Destroy(gameObject);
    }
  }

  // Add/subtract money to the player's total
  public int AddMoney(int amount) {
    return playerMoney += amount;
  }


  // Get the player's current money
  public int GetPlayerMoney() {
    return playerMoney;
  }
}