using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace GameDevRunner.UI
{
    public class PointSliderUI : MonoBehaviour
    {
        [SerializeField] private GameSizeGeneralInfo gameSizeInfo;
        [Space]
        [SerializeField] private Slider slider;
        [SerializeField] private Image fillImage;
        [SerializeField] private TextMeshProUGUI textMesh;

        private Tween sliderTween;
        private SizeInfo currentSizeInfo;

        #region MonoBehaviour Methods
        private void OnEnable()
        {
            StaticEvents.onPointCollected += OnPointCollected;
            StaticEvents.levelStarted += OnGameStart;
            StaticEvents.onPathEnded += OnGameEnded;
        }

        private void OnDisable()
        {
            StaticEvents.onPointCollected -= OnPointCollected;
            StaticEvents.levelStarted -= OnGameStart;
            StaticEvents.onPathEnded -= OnGameEnded;
        }
        #endregion

        #region EVENT LISTENERS
        private void OnPointCollected(int value)
        {
            (SizeInfo sizeInfo, int maxValue) = gameSizeInfo.GameSizeCheck(value);
            if (currentSizeInfo == null || sizeInfo != currentSizeInfo)
            {
                currentSizeInfo = sizeInfo;

                slider.minValue = currentSizeInfo.MinLimit;
                slider.maxValue = maxValue;
                textMesh.text = currentSizeInfo.GameSize.ToString();
                fillImage.DOColor(currentSizeInfo.ColorInfo, 0.25f);
            }

            if (sliderTween != null)
            {
                sliderTween.Kill();
            }

            value = (int)Mathf.Clamp(value, slider.minValue, slider.maxValue);
            sliderTween = slider.DOValue(value, 0.1f).OnKill(() =>
             {
                 slider.value = value;
             });

        }

        private void OnGameStart()
        {
            slider.gameObject.SetActive(true);
        }

        private void OnGameEnded()
        {
            slider.gameObject.SetActive(false);
        }
        #endregion
    }
}