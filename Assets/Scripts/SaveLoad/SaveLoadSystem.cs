using Data;
using UnityEngine;
using Utils;

namespace SaveLoad {
  public class SaveLoadSystem {
    public SaveLoadSystem() {
      LoadBalance();
    }

    public Balance LoadBalance() {
      Balance data;
      var key = GameConstants.BalanceKey;
      if (PlayerPrefs.HasKey(key)) {
        data = new Balance {
          CoinsAmount = PlayerPrefs.GetInt(key)
        };
      } else {
        data = new Balance();
        SaveBalance(data);
      }

      return data;
    }

    public void AddCoins(int amount) {
      PlayerPrefs.SetInt(GameConstants.BalanceKey, PlayerPrefs.GetInt(GameConstants.BalanceKey) + amount);
    }

    public int GetCoins() {
      return PlayerPrefs.GetInt(GameConstants.BalanceKey);
    }

    private void SaveBalance(Balance data) {
      PlayerPrefs.SetInt(GameConstants.BalanceKey, data.CoinsAmount);
      PlayerPrefs.Save();
    }
  }
}