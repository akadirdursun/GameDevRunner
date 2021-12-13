using UnityEngine;
using UnityEngine.UI;

namespace GameDevRunner
{
    public class UIManager : MonoBehaviour
    {
        [Header("Sliders")]
        [SerializeField] private Slider designPointSlider;
        [SerializeField] private Slider technologyPointSlider;
        [SerializeField] private Slider artPointSlider;

        private GeneralInfoesSO generalInfo;

        #region MonoBehaviour Methods
        private void OnEnable()
        {
            StaticEvents.generalInfoPost += SetGeneralInfo;
        }

        private void OnDisable()
        {
            StaticEvents.generalInfoPost -= SetGeneralInfo;
        }
        #endregion

        private void SetGeneralInfo(GeneralInfoesSO _info)
        {
            generalInfo = _info;
            generalInfo.UIManager = this;
        }

        public void IncreaseSlider(int _value, CollectableTypes _type)
        {
            switch (_type)
            {
                case CollectableTypes.designPoint:
                    designPointSlider.value += _value;
                    break;
                case CollectableTypes.technologyPoint:
                    technologyPointSlider.value += _value;
                    break;
                case CollectableTypes.artPoint:
                    artPointSlider.value += _value;
                    break;
            }
        }
    }
}