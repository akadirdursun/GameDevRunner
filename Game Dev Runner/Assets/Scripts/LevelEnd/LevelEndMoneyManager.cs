using UnityEngine;
using DG.Tweening;

namespace GameDevRunner.LevelEnd
{
    public class LevelEndMoneyManager : MonoBehaviour
    {
        [SerializeField] private MeshRenderer moneyModel;
        [SerializeField] private float valuePerMoney = 1f;

        private GeneralInfoesSO generalInfo;

        public float moneySize
        {
            get
            {
                return moneyModel.bounds.size.y;
            }
        }

        public float ValuePerMoney { get => valuePerMoney; }

        #region MonoBehaviour METHODS
        private void OnEnable()
        {
            StaticEvents.generalInfoPost += GetGeneralInfo;
            StaticEvents.onVerticalPlatformReached += LevelEndRoutine;
        }

        private void OnDisable()
        {
            StaticEvents.generalInfoPost -= GetGeneralInfo;
            StaticEvents.onVerticalPlatformReached -= LevelEndRoutine;
        }
        #endregion

        private void LevelEndRoutine()
        {
            int totalValue = generalInfo.GameSizes.GetProfit(generalInfo.StudioInfo.CurrentGame.GetTotalValue());            
            int count = (int)(totalValue / valuePerMoney);

            for (int i = 0; i < count; i++)
            {
                Transform newMoney = Instantiate(moneyModel, moneyModel.transform.parent).transform;

                Vector3 localPos = moneyModel.transform.localPosition;
                localPos.y = -((i + 1) * moneySize);
                newMoney.localPosition = localPos;
            }

            transform.DOLocalMoveY(count * moneySize, 1f).SetDelay(2f).OnComplete(() =>
            {
                //TODO: LevelEnded Event
            });
        }

        private void GetGeneralInfo(GeneralInfoesSO info)
        {
            generalInfo = info;
        }
    }
}