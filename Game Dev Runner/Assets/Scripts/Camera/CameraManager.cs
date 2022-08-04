using UnityEngine;
using DG.Tweening;

namespace GameDevRunner
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private CameraFollowSwipe cameraSwipeScript;
        [SerializeField] private Vector3 positionOffset;
        [SerializeField] private Vector3 rotationOffset;

        #region EVENT LISTENERS
        private void OnCameraOffsetChange(Vector3 addValue)
        {
            cameraSwipeScript.transform.DOLocalMoveZ(cameraSwipeScript.transform.localPosition.z - 1, 0.5f);
        }
        #endregion

        #region MonoBehaviour METHODS
        private void OnEnable()
        {
            StaticEvents.addCameraOffset += OnCameraOffsetChange;
        }

        private void OnDisable()
        {
            StaticEvents.addCameraOffset -= OnCameraOffsetChange;
        }

        private void OnValidate()
        {
            if (cameraSwipeScript == null) return;

            cameraSwipeScript.transform.localPosition = positionOffset;
            cameraSwipeScript.transform.localEulerAngles = rotationOffset;
        }
        #endregion
    }
}