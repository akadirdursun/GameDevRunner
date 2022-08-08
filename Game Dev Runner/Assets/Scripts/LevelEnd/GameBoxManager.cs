using UnityEngine;
using TMPro;
using DG.Tweening;

namespace GameDevRunner.LevelEnd
{
    public class GameBoxManager : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private TextMeshPro textMesh;

        private GeneralInfoesSO generalInfo;

        #region MonoBehaviour METHODS
        private void OnEnable()
        {
            StaticEvents.generalInfoPost += GetGeneralInfo;
            StaticEvents.onPathEnded += LevelEndRoutine;
        }
        private void OnDisable()
        {
            StaticEvents.generalInfoPost -= GetGeneralInfo;
        }
        #endregion

        private void LevelEndRoutine()
        {
            SizeInfo targetSizeInfo = generalInfo.GameSizes.GameSizeCheck(generalInfo.StudioInfo.CurrentGame.GetTotalValue()).Item1;

            Sequence sequence = DOTween.Sequence();
            sequence.SetDelay(1f);
            for (int i = 0; i <= (int)targetSizeInfo.GameSize; i++)
            {
                SizeInfo sizeInfo = generalInfo.GameSizes.GetSizeInfo(i);
                Tween tween = spriteRenderer.DOColor(sizeInfo.ColorInfo, 0.5f).OnComplete(() =>
                {
                    textMesh.text = sizeInfo.GameSize.ToString();
                });
                sequence.Append(tween);
            }
            sequence.OnComplete(() =>
            {
                StaticEvents.onVerticalPlatformReached?.Invoke();
            });
        }
        private void GetGeneralInfo(GeneralInfoesSO info)
        {
            generalInfo = info;
        }
    }
}