using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevRunner
{
    [CreateAssetMenu(menuName = "GeneralInfo", fileName = "NewGeneralInfo")]
    public class GeneralInfoesSO : ScriptableObject
    {
        [Header("Managers")]
        private GameManager gameManager;
        [Header("Color")]
        [SerializeField] private Color designerColor = new Color32(217, 98, 0, 255);
        [SerializeField] private Color technologyColor = new Color32(0, 47, 229, 255);
        [SerializeField] private Color artistColor = new Color32(200, 3, 86, 255);

        #region Properties
        public GameManager GManager { get => gameManager; set => gameManager = value; }
        public Color DesignerColor { get => designerColor; }
        public Color TechnologyColor { get => technologyColor; }
        public Color ArtistColor { get => artistColor; }
        #endregion
    }
}