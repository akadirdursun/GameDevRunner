using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevRunner.UI
{
    public class GeneralUIManager : MonoBehaviour
    {
        [SerializeField] private GameObject levelEndUI;

        #region EVENT LISTENERS
        private void OnLEvelCompleted()
        {
            Run.After(1f, () =>
            {
                levelEndUI.SetActive(true);
            });
        }
        #endregion

        #region MonoBehaviour METHODS
        private void OnEnable()
        {
            StaticEvents.levelCompleted += OnLEvelCompleted;
        }

        private void OnDisable()
        {
            StaticEvents.levelCompleted -= OnLEvelCompleted;
        }
        #endregion
    }
}