using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace GameDevRunner
{    
    public class Character : MonoBehaviour
    {

        [SerializeField] private Jobs job;
        [Header("Color")]
        [SerializeField] private Color designerColor;
        [SerializeField] private Color developerColor;
        [SerializeField] private Color artistColor;
        [Header("UI")]
        [SerializeField] private TextMeshProUGUI nameText;

        #region Properties
        public Jobs Job { get => job; }
        #endregion

        #region MonoBehaviour Methods
        private void Start()
        {
            SetTheCharacter();
        }
        #endregion

        private void SetTheCharacter()
        {
            switch (job)
            {
                case Jobs.Designer:
                    GetComponent<MeshRenderer>().material.color = designerColor;
                    break;
                case Jobs.Developer:
                    GetComponent<MeshRenderer>().material.color = developerColor;
                    break;
                case Jobs.Artist:
                    GetComponent<MeshRenderer>().material.color = artistColor;
                    break;
            }

            nameText.text = job.ToString();
        }
    }
}