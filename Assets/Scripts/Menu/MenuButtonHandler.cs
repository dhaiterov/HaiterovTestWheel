using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Utils;

namespace Menu {
  public class MenuButtonHandler : MonoBehaviour {
    [SerializeField]
    private Button _playButton;


    private void Awake() {
      _playButton.onClick.AddListener(OnPlayButtonClick);
    }

    private void OnDestroy() {
      _playButton.onClick.RemoveListener(OnPlayButtonClick);
    }

    private void OnPlayButtonClick() {
      SceneManager.LoadSceneAsync(GameConstants.GameSceneName);
    }
  }
}