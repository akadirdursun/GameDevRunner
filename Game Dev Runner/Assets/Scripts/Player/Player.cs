using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevRunner
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private StudioInfo studioInfo;
        [SerializeField] private GameInfo gameInfo;        

        private void Start()
        {
            DevelopNewGame();
        }

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
            gameInfo.AddPoint(_type);
        }
    }
}