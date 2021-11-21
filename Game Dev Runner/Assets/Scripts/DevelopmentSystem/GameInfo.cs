using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevRunner
{
    [System.Serializable]
    public class GameInfo
    {
        [SerializeField] private string gameName;

        [Header("Design")]
        [SerializeField] private int currentDesignPoint;
        [SerializeField] private int minDesignPoint;
        private int designMultiplier = 1;
        private int designBaseIncrement = 1;

        [Header("Tecnology")]
        [SerializeField] private int currentTechnologyPoint;
        [SerializeField] private int minTechnologyPoint;
        private int technologyMultiplier = 1;
        private int technologyBaseIncrement = 1;

        [Header("Art")]
        [SerializeField] private int currentArtPoint;
        [SerializeField] private int minArtPoint;
        private int artMultiplier = 1;
        private int artBaseIncrement = 1;

        [Header("Workers")]
        private int designerCount = 0;
        private int developerCount = 0;
        private int artistCount = 0;        

        #region Properties
        public int DesignerCount { get => designerCount; set => designerCount = value; }
        public int DeveloperCount { get => developerCount; set => developerCount = value; }
        public int ArtistCount { get => artistCount; set => artistCount = value; }
        #endregion
        
        public void AddPoint(CollectableTypes _type)
        {
            switch (_type)
            {
                case CollectableTypes.designPoint:
                    int dp = (designBaseIncrement * designMultiplier);
                    currentDesignPoint += (dp + (dp * designerCount));
                    break;

                case CollectableTypes.technologyPoint:
                    int tp = (technologyBaseIncrement * technologyMultiplier);
                    currentTechnologyPoint += (tp + (tp * developerCount));
                    break;

                case CollectableTypes.artPoint:
                    int ap = (artBaseIncrement * artMultiplier);
                    currentArtPoint += (ap + (ap * artistCount));
                    break;
            }
        }
    }
}