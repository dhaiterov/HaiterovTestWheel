using Data;
using UnityEngine;

namespace Configs {
  [CreateAssetMenu(fileName = "Wheel", menuName = "Configs/WheelLevel")]
  public class WheelLevelConfig : ScriptableObject {
    public WheelLevelData WheelLevelData;
  }
}