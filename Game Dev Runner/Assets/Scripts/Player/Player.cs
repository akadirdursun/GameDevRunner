using UnityEngine;
using TMPro;

namespace GameDevRunner
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private StudioInfo studioInfo;
        [SerializeField] private GameInfo gameInfo;
        [Header("Pop-Up Text")]
        [SerializeField] private TextMeshPro popUpPrefab;
        [SerializeField] private Transform popUpTextHolder;

        private GeneralInfoesSO generalInfoes;

        public GameInfo GameInfo { get => gameInfo; }

        #region MonoBehaviour Methods
        private void OnEnable()
        {
            StaticEvents.generalInfoPost += GetGeneralInfo;
        }

        private void OnDisable()
        {
            StaticEvents.generalInfoPost -= GetGeneralInfo;
        }

        private void Start()
        {
            DevelopNewGame();
        }
        #endregion

        private void DevelopNewGame()
        {
            gameInfo = new GameInfo();
            studioInfo.CurrentGame = gameInfo;
        }
        public void IncreaseWorkerCount(Jobs _job)
        {
            switch (_job)
            {
                case Jobs.Designer:
                    gameInfo.DesignerCount++;
                    break;
                case Jobs.Developer:
                    gameInfo.DeveloperCount++;
                    break;
                case Jobs.Artist:
                    gameInfo.ArtistCount++;
                    break;
            }
        }

        public void IncreaseGamePoint(CollectableTypes _type)
        {
            int result = gameInfo.AddPoint(_type);
            TextMeshPro popUp = Instantiate(popUpPrefab, popUpTextHolder);
            popUp.color = GetCollectableColor(_type);
            popUp.transform.localPosition += (Vector3.right * Random.Range(-1f, 1f));
            popUp.text = "+" + result.ToString();
        }

        private void GetGeneralInfo(GeneralInfoesSO _info)
        {
            generalInfoes = _info;
        }

        private Color GetCollectableColor(CollectableTypes _type)
        {
            if (generalInfoes == null) return Color.white;

            Color c = Color.white;
            switch (_type)
            {
                case CollectableTypes.designPoint:
                    c = generalInfoes.DesignerColor;
                    break;
                case CollectableTypes.technologyPoint:
                    c = generalInfoes.TechnologyColor;
                    break;
                case CollectableTypes.artPoint:
                    c = generalInfoes.ArtistColor;
                    break;
            }

            return c;
        }
    }
}