using UnityEngine;
using DG.Tweening;

namespace GameDevRunner.LevelEnd
{
    public class LevelEndMoneyManager : MonoBehaviour
    {
        [SerializeField] private MeshRenderer moneyModel;
        [SerializeField] private float valuePerMoney = 1f;

        public float moneySize
        {
            get
            {
                return moneyModel.bounds.size.y;
            }
        }

        public float ValuePerMoney { get => valuePerMoney; }

        public void LevelEndRoutine(int totalValue)
        {
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
    }
}