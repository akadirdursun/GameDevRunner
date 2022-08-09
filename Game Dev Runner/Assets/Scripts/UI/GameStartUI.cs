using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevRunner.UI
{
    public class GameStartUI : MonoBehaviour
    {
        public void OnStartButtonClicked()
        {
            StaticEvents.levelStarted?.Invoke();
            gameObject.SetActive(false);
        }
    }
}