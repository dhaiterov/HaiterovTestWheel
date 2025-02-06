using System.Collections.Generic;
using Configs;
using Events;
using SaveLoad;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using Wheel;
using Zenject;
using Random = UnityEngine.Random;

namespace View {
  public class WheelView : MonoBehaviour {
    [SerializeField]
    private RectTransform _spawnTransform;

    [SerializeField]
    private RectTransform _sectorParentTransform;

    [SerializeField]
    private Button _spinButton;

    private RandomSectorGenerator _randomSectorGenerator;
    private SaveLoadSystem _saveLoadSystem;

    private List<int> _sectorValues;


    private WheelSectorView.Factory _viewSectorFactory;
    private WheelAnimation _wheelAnimation;
    private WheelLevelConfig _wheelConfig;

    
    [Inject]
    private void Construct(WheelSectorView.Factory wheelSectorViewFactory, WheelLevelConfig wheelLevelConfig) {
      _viewSectorFactory = wheelSectorViewFactory;
      _wheelConfig = wheelLevelConfig;
      _saveLoadSystem = new SaveLoadSystem();
    }

    private void Awake() {
      _wheelAnimation = new WheelAnimation();
      _randomSectorGenerator = new RandomSectorGenerator();
      _spinButton.onClick.AddListener(OnSpinButtonClicked);
      EventManager.AddListener(EventConstants.EndWheelAnimation, OnEndWheelAnimation);
    }

    private void OnDestroy() {
      _spinButton.onClick.RemoveListener(OnSpinButtonClicked);
      EventManager.RemoveListener(EventConstants.EndWheelAnimation, OnEndWheelAnimation);
    }

    private void OnEndWheelAnimation() {
      _spinButton.interactable = true;
    }

    private void OnSpinButtonClicked() {
      _spinButton.interactable = false;
      var minValue = 0;
      var maxValue = _wheelConfig.WheelLevelData.SectorCount;
      var winSector = Random.Range(minValue, maxValue);
      _saveLoadSystem.AddCoins(SectorReward(winSector));
      _wheelAnimation.StartRotateAnimation(_sectorParentTransform, _wheelConfig.WheelLevelData.SectorCount, winSector);
    }

    public void SetupData() {
      CreateWheel(_wheelConfig.WheelLevelData.SectorCount);
    }

    public void CreateWheel(int sectorCount) {
      _sectorValues = _randomSectorGenerator.GenerateUniqueSegments(_wheelConfig.WheelLevelData);
      var angleValue = GameConstants.CircleAngle / sectorCount;
      for (var i = 0; i < sectorCount; i++) {
        CreateSector(i, angleValue * i);
      }
    }

    private void CreateSector(int index, float angle) {
      var item = _viewSectorFactory.Create();
      item.transform.SetParent(_sectorParentTransform);
      item.transform.localScale = Vector3.one;
      item.transform.position = _spawnTransform.position;
      item.transform.rotation = Quaternion.Euler(0, 0, angle + GameConstants.RotationBlending);
      item.InitView(SectorReward(index));
    }

    private int SectorReward(int id) {
      return _sectorValues[id];
    }

    public class Factory : PlaceholderFactory<WheelView> {
    }
  }
}