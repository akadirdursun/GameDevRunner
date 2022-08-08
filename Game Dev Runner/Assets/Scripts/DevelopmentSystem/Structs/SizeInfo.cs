using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevRunner
{
    [System.Serializable]
    public class SizeInfo
    {
        [SerializeField] private GameSizes gameSize;
        [SerializeField] private int minLimit;
        [SerializeField] private Color color;
        [Space]
        [SerializeField] private int minProfit;
        [SerializeField] private int maxProfit;

        public GameSizes GameSize { get => gameSize; }
        public int MinLimit { get => minLimit; }
        public Color ColorInfo { get => color; }

        public int GetProfit()
        {
            return Random.Range(minProfit, maxProfit);
        }
    }

    public enum GameSizes
    {
        B,
        BB,
        A,
        AA,
        AAA
    }
}