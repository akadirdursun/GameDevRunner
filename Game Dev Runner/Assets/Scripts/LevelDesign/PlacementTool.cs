using UnityEngine;
using PathCreation;

namespace GameDevRunner.LevelDesign
{
    public class PlacementTool : MonoBehaviour
    {
        [SerializeField][Range(0f, 1f)] private float positionOnPath = 0.01f;
        [Header("Horizontal Position")]
        [SerializeField] private Transform horizontalPositionHandler;
        [SerializeField][Range(-10f, 10f)] private float xPositionOnPath = 0f;

        private PathCreator levelPathCreator;

        protected PathCreator LevelPathCreator
        {
            get
            {
                if (levelPathCreator == null)
                    levelPathCreator = FindObjectOfType<PathCreator>();

                return levelPathCreator;
            }
        }

        #region MonoBehaviour METHODS
        private void OnValidate()
        {
            if (LevelPathCreator != null && UnityEngine.SceneManagement.SceneManager.GetActiveScene().isLoaded)
            {
                transform.position = levelPathCreator.path.GetPointAtTime(positionOnPath, EndOfPathInstruction.Stop);
                transform.rotation = levelPathCreator.path.GetRotation(positionOnPath, EndOfPathInstruction.Stop);
            }


            if (horizontalPositionHandler != null)
            {
                Vector3 localPos = horizontalPositionHandler.localPosition;
                localPos.x = xPositionOnPath;
                horizontalPositionHandler.localPosition = localPos;
            }
        }
        #endregion
    }
}