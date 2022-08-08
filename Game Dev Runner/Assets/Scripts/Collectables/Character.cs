using UnityEngine;
using TMPro;
using UnityEngine.Animations;

namespace GameDevRunner.Collectables
{
    public class Character : MonoBehaviour
    {

        [SerializeField] private Jobs job;
        [Space]
        [SerializeField] private SkinnedMeshRenderer smRenderer;
        [Header("UI")]
        [SerializeField] private TextMeshProUGUI nameText;

        #region Properties
        public Jobs Job { get => job; }
        #endregion

        #region MonoBehaviour Methods
        private void OnEnable()
        {
            StaticEvents.generalInfoPost += SetTheCharacter;
            ActivateRotationConstraint();
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
                    smRenderer.material.color = _info.DesignerColor;
                    nameText.color = _info.DesignerColor;
                    break;
                case Jobs.Developer:
                    smRenderer.material.color = _info.TechnologyColor;
                    nameText.color = _info.TechnologyColor;
                    break;
                case Jobs.Artist:
                    smRenderer.material.color = _info.ArtistColor;
                    nameText.color = _info.ArtistColor;
                    break;
            }

            nameText.text = job.ToString();
        }

        private void ActivateRotationConstraint()
        {
            RotationConstraint contstraint = GetComponentInChildren<RotationConstraint>();

            ConstraintSource source = new ConstraintSource();
            source.sourceTransform = Camera.main.transform;
            source.weight = 1f;

            contstraint.AddSource(source);
            contstraint.constraintActive = true;
        }
    }
}