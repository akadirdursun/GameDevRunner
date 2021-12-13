using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevRunner {
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GeneralInfoesSO generalInfo;
        private void Awake()
        {
            generalInfo.GManager = this;
        }
        private void Start()
        {
            if (generalInfo != null)
            {
                StaticEvents.generalInfoPost?.Invoke(generalInfo);                
            }
        }
    }
}