using Configs;
using UnityEngine;
using Utils;
using Zenject;

namespace Installers {
  public class ConfigInstaller : MonoInstaller {
    public override void InstallBindings() {
      var levelConfig = Resources.Load<WheelLevelConfig>(GameConstants.WheelLevelPath);
      Container.BindInstance(levelConfig).AsSingle();
    }
  }
}