using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace GameDevRunner
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager instance;

        [Header("Multiplier Texts")]
        [SerializeField] private TextMeshProUGUI designMultiplierText;
        [SerializeField] private TextMeshProUGUI technologyMultiplierText;
        [SerializeField] private TextMeshProUGUI artMultiplierText;
        [Space]
        [SerializeField] private Image fillImage;
        [SerializeField] private TextMeshProUGUI fillText;

        #region MonoBehaviour Methods
        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else { Destroy(this); }
        }
        #endregion

        public void SetValue(float _value, float _maxValue)
        {
            fillImage.fillAmount = (1 / _maxValue) * _value;
            fillText.text = _value + " / " + _maxValue;
        }

        public void SetNodeMultipliers(GameInfo _info)
        {
            designMultiplierText.text = "x" + _info.DesignMultiplier;
            designMultiplierText.gameObject.SetActive(true);

            technologyMultiplierText.text = "x" + _info.TechnologyMultiplier;
            technologyMultiplierText.gameObject.SetActive(true);

            artMultiplierText.text = "x" + _info.ArtMultiplier;
            artMultiplierText.gameObject.SetActive(true);
        }

        public void SetFillText(int _maxValue)
        {
            fillText.text = "0 / " + _maxValue;
        }
    }
}