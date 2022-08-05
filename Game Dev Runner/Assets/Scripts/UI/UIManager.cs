using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace GameDevRunner
{
    public class UIManager : MonoBehaviour
    {
        #region Singleton
        public static UIManager instance;

        private void InitializeSingleton()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(this);
            }
        }
        #endregion

        [SerializeField] private Slider slider;
        [SerializeField] private TextMeshProUGUI textMesh;

        #region MonoBehaviour Methods
        private void Awake()
        {
            InitializeSingleton();
        }
        #endregion

        public void PointCollected(int value)
        {

        }
    }
}