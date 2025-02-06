using Data;
using Events;
using SaveLoad;
using TMPro;
using UnityEngine;
using Utils;

namespace View {
  public class BalanceHandler : MonoBehaviour {
    [SerializeField]
    private TMP_Text _balanceText;

    private Balance _balance;
    private SaveLoadSystem _saveLoadSystem;

    private void Awake() {
      InitBalance();
      EventManager.AddListener(EventConstants.EndWheelAnimation, OnEndWheelAnimation);
    }

    private void OnDestroy() {
      EventManager.RemoveListener(EventConstants.EndWheelAnimation, OnEndWheelAnimation);
    }

    private void OnEndWheelAnimation() {
      UpdateView();
    }


    private void InitBalance() {
      _saveLoadSystem = new SaveLoadSystem();
      _balance = _saveLoadSystem.LoadBalance();
      UpdateView();
    }

    private void UpdateView() {
      _balanceText.text = Text(_saveLoadSystem.GetCoins());
    }

    private string Text(int reward) {
      if (reward >= GameConstants.Million) {
        return (reward / 1000000f).ToString("0.##") + "M";
      }

      if (reward >= GameConstants.Thousand) {
        return (reward / 1000f).ToString("0.##") + "K";
      }

      return reward.ToString();
    }
  }
}