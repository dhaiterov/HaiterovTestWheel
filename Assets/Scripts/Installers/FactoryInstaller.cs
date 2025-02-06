using UnityEngine;
using View;
using Zenject;

namespace Installers {
  public class FactoryInstaller : MonoInstaller {
    [SerializeField]
    private WheelView _wheelView;
    [SerializeField]
    private WheelSectorView _wheelSectorView;
    [SerializeField]
    private Transform _gameFieldTransform;

    public override void InstallBindings() {
      Container.BindFactory<WheelView, WheelView.Factory>()
        .FromComponentInNewPrefab(_wheelView).UnderTransform(_gameFieldTransform);
      Container.BindFactory<WheelSectorView, WheelSectorView.Factory>()
        .FromComponentInNewPrefab(_wheelSectorView);
    }
  }
}