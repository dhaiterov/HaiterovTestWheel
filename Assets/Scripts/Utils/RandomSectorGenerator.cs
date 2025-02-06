using System.Collections.Generic;
using Data;
using UnityEngine;
using Random = System.Random;

namespace Utils {
  public class RandomSectorGenerator {
    public List<int> GenerateUniqueSegments(WheelLevelData data) {
      var segments = new List<int>();
      var rnd = new Random();
      while (segments.Count < data.SectorCount) {
        var number = rnd.Next(data.MinRewardValue / data.StepCount, data.MaxRewardValue / data.StepCount + 1) *
                     data.StepCount;
        var isUniqueAndValid = true;
        foreach (var seg in segments) {
          if (Mathf.Abs(seg - number) < data.Interval) {
            isUniqueAndValid = false;
            break;
          }
        }

        if (isUniqueAndValid) {
          segments.Add(number);
        }
      }

      segments.Sort();
      return segments;
    }
  }
}