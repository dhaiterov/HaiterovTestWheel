using DG.Tweening;
using Events;
using UnityEngine;
using Utils;

namespace Wheel {
  public class WheelAnimation {
    public void StartRotateAnimation(Transform transform, int totalSectors, int sectorIndex) {
      var angleValue = GameConstants.CircleAngle / totalSectors;
      angleValue *= sectorIndex;
      angleValue += GameConstants.RotationBlending;
      var finalAngle = -angleValue + GameConstants.RotationBlending;
      var currentAngle = transform.localEulerAngles.z;
      var angleDifference = Mathf.DeltaAngle(currentAngle, finalAngle);
      var totalAngle = angleDifference + GameConstants.CircleAngle * GameConstants.FakeRotationsAmount;
      transform.DORotate(new Vector3(0, 0, currentAngle + totalAngle), GameConstants.RotateDuration,
          RotateMode.FastBeyond360)
        .SetEase(Ease.InOutQuart).OnComplete(() => EventManager.Invoke(EventConstants.EndWheelAnimation));
    }
  }
}