using System.Collections.Generic;
using UnityEngine;

namespace GameDevRunner
{
    [CreateAssetMenu(menuName = "Game Size Infoes", fileName = "GameSizeInfo")]
    public class GameSizeGeneralInfo : ScriptableObject
    {
        [SerializeField] private List<SizeInfo> sizeInfoes = new List<SizeInfo>();

        public (SizeInfo, int) GameSizeCheck(int totalValue)
        {
            for (int i = sizeInfoes.Count - 1; i >= 0; i--)
            {
                if (totalValue >= sizeInfoes[i].MinLimit)
                {
                    int maxSize = i < sizeInfoes.Count - 1 ? sizeInfoes[i + 1].MinLimit : sizeInfoes[i].MinLimit + 1;
                    return (sizeInfoes[i], maxSize);
                }
            }

            return (sizeInfoes[0], sizeInfoes[1].MinLimit);
        }

        public SizeInfo GetSizeInfo(int index)
        {
            index = Mathf.Clamp(index, 0, sizeInfoes.Count - 1);
            return sizeInfoes[index];
        }

        public int GetProfit(int totalPointValue)
        {
            return GameSizeCheck(totalPointValue).Item1.GetProfit();
        }
    }
}