using Data;
using TMPro;
using UnityEngine;
using Utils;
using Zenject;

namespace View {
  public class WheelSectorView : MonoBehaviour {
    [SerializeField]
    private TMP_Text _rewardText;

    private SectorRewardData _data;

    private void Awake() {
      _data = new SectorRewardData();
    }

    public void InitView(int reward) {
      _data.rewardValue = reward;
      SetupText(reward);
    }

    private void SetupText(int reward) {
      if (reward >= GameConstants.Million) {
        _rewardText.text = (reward / 1000000f).ToString("0.#") + "m";
      } else if (reward >= GameConstants.Thousand) {
        _rewardText.text = (reward / 1000f).ToString("0.#") + "k";
      } else {
        _rewardText.text = reward.ToString();
      }
    }

    public class Factory : PlaceholderFactory<WheelSectorView> {
    }
  }
}