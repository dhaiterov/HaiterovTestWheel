using System;

namespace Utils {
  [Serializable]
  public class GameConstants {
    public const string GameSceneName = "Game";
    public const string BalanceKey = "BalanceKey";
    public const string WheelLevelPath = "Configs/WheelLevel";
    public const float CircleAngle = 360f;
    public const float RotationBlending = 10f;
    public const int FakeRotationsAmount = 5;
    public const int Million = 1000000;
    public const int Thousand = 1000;
    public const float RotateDuration = 3f;
  }
}