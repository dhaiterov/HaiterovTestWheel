using Configs;
using UnityEngine;
using View;
using Zenject;

namespace Spawners {
  public class WheelSpawner : MonoBehaviour {
    [SerializeField]
    private Transform _spawnPoint;

    private WheelLevelConfig _wheelConfig;
    private WheelView.Factory _wheelFactory;

    private void OnEnable() {
      SpawnWheel();
    }


    [Inject]
    private void Construct(WheelView.Factory wheelFactory, WheelLevelConfig wheelConfig) {
      _wheelFactory = wheelFactory;
      _wheelConfig = wheelConfig;
    }

    private void SpawnWheel() {
      var wheel = _wheelFactory.Create();
      wheel.transform.SetParent(_spawnPoint);
      wheel.SetupData();
    }
  }
}