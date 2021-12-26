using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevRunner
{
    [System.Serializable]
    public class GameInfo
    {
        [SerializeField] private string gameName;
        private GameGenres genre = null;
        private GameSize size = null;

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
        public GameSize Size
        {
            get => size;
            set
            {
                if (size != null) return;

                size = value;
                UIManager.instance?.SetFillText(size.PointToComplete);
            }
        }

        public int DesignMultiplier { get => designMultiplier; }
        public int TechnologyMultiplier { get => technologyMultiplier; }
        public int ArtMultiplier { get => artMultiplier; }
        #endregion

        #region Private Methods
        private ref int GetChoosenMultiplier(CollectableTypes _type)
        {
            switch (_type)
            {
                case CollectableTypes.designPoint:
                    return ref designMultiplier;
                case CollectableTypes.technologyPoint:
                    return ref technologyMultiplier;
                case CollectableTypes.artPoint:
                    return ref artMultiplier;
                default:
                    return ref designMultiplier;
            }
        }
        #endregion

        public int AddPoint(CollectableTypes _type)
        {
            int result = 0;

            switch (_type)
            {
                case CollectableTypes.designPoint:
                    int dp = (designBaseIncrement * designMultiplier);
                    result = (dp + (dp * designerCount));
                    currentDesignPoint += result;
                    //UIManager.instance?.SetValue(currentDesignPoint, _type);
                    break;

                case CollectableTypes.technologyPoint:
                    int tp = (technologyBaseIncrement * technologyMultiplier);
                    result = (tp + (tp * developerCount));
                    currentTechnologyPoint += result;
                    //UIManager.instance?.SetValue(currentTechnologyPoint, _type);
                    break;

                case CollectableTypes.artPoint:
                    int ap = (artBaseIncrement * artMultiplier);
                    result = (ap + (ap * artistCount));
                    currentArtPoint += result;
                    //UIManager.instance?.SetValue(currentArtPoint, _type);
                    break;
            }

            SetUI();
            return result;
        }

        public void SetMultipliers(GameGenres _genre)
        {
            GetChoosenMultiplier(_genre.PrimaryType) = 3;
            GetChoosenMultiplier(_genre.SecondaryType) = 2;

            UIManager.instance?.SetNodeMultipliers(this);
        }

        public void SetGenre(GameGenres _genre)
        {
            if (genre != null) return;

            genre = _genre;
            SetMultipliers(_genre);
        }

        private void SetUI()
        {
            int totalPoint = currentDesignPoint + currentTechnologyPoint + currentArtPoint;
            UIManager.instance?.SetValue(totalPoint, size.PointToComplete);
        }
    }
}