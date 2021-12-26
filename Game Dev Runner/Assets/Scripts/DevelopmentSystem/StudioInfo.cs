using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevRunner
{
    [CreateAssetMenu(fileName = "StudioInfo", menuName = "StudioData")]
    public class StudioInfo : ScriptableObject
    {
        [SerializeField] private string studioName;
        [Header("Games")]
        [SerializeField] private GameInfo currentGame;
        [Space]
        [SerializeField] private List<GameInfo> games = new List<GameInfo>();

        #region Events
        private Action newGame;
        #endregion

        #region Properties
        public GameInfo CurrentGame
        {
            get => currentGame;
            set
            {
                currentGame = value;
                newGame?.Invoke();
            }
        }
        #endregion

        public void Initiate(string _name = "")
        {
            studioName = _name;
        }
    }
}