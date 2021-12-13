using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GameDevRunner
{
    public class Character : MonoBehaviour
    {

        [SerializeField] private Jobs job;
        [Header("UI")]
        [SerializeField] private TextMeshProUGUI nameText;

        #region Properties
        public Jobs Job { get => job; }
        #endregion

        #region MonoBehaviour Methods
        private void OnEnable()
        {
            StaticEvents.generalInfoPost += SetTheCharacter;
        }

        private void OnDisable()
        {
            StaticEvents.generalInfoPost -= SetTheCharacter;
        }
        #endregion

        private void SetTheCharacter(GeneralInfoesSO _info)
        {
            switch (job)
            {
                case Jobs.Designer:
                    GetComponent<MeshRenderer>().material.color = _info.DesignerColor;
                    nameText.color = _info.DesignerColor;
                    break;
                case Jobs.Developer:
                    GetComponent<MeshRenderer>().material.color = _info.TechnologyColor;
                    nameText.color = _info.TechnologyColor;
                    break;
                case Jobs.Artist:
                    GetComponent<MeshRenderer>().material.color = _info.ArtistColor;
                    nameText.color = _info.ArtistColor;
                    break;
            }

            nameText.text = job.ToString();
        }
    }
}