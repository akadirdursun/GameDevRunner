using UnityEngine;
using DG.Tweening;

namespace GameDevRunner.CameraControlls
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private CameraFollowSwipe cameraSwipeScript;
        [SerializeField] private float offsetChangeTime = 0.5f;
        [Space]
        [Space][SerializeField] private OffsetDisplayMode offsetDisplayMode;
        [Space]
        [Header("Offsets")]
        [SerializeField] private CameraOffsetInfo runnerOffset;
        [Space][SerializeField] private CameraOffsetInfo levelEndOffset;
        [Space][SerializeField] private CameraOffsetInfo verticalPlatformOffset;

        private CameraFollowForward followScript;

        #region EVENT LISTENERS
        private void OnCameraOffsetChange(Vector3 addValue)
        {
            cameraSwipeScript.transform.DOLocalMoveZ(cameraSwipeScript.transform.localPosition.z - 1, offsetChangeTime);
        }

        private void OnPathEnded()
        {
            cameraSwipeScript.enabled = false;
            followScript.enabled = false;
            cameraSwipeScript.transform.DOLocalMove(levelEndOffset.PositionOffset, offsetChangeTime);
            cameraSwipeScript.transform.DOLocalRotate(levelEndOffset.RotationOffset, offsetChangeTime);

            transform.DOMove(levelEndOffset.Target.position, offsetChangeTime).OnComplete(() =>
            {
                followScript.Target = levelEndOffset.Target;
                followScript.enabled = true;
            });
        }

        private void OnVerticalPlatformReached()
        {
            followScript.enabled = false;
            cameraSwipeScript.transform.DOLocalRotate(verticalPlatformOffset.RotationOffset, offsetChangeTime);
            cameraSwipeScript.transform.DOLocalMove(verticalPlatformOffset.PositionOffset, offsetChangeTime);

            transform.DOMove(verticalPlatformOffset.Target.position, offsetChangeTime).OnComplete(() =>
            {
                followScript.Target = verticalPlatformOffset.Target;
                followScript.enabled = true;
            });
        }
        #endregion

        #region MonoBehaviour METHODS
        private void OnValidate()
        {
            if (cameraSwipeScript == null) return;

            CameraOffsetInfo currentOffset = null;
            switch (offsetDisplayMode)
            {
                case OffsetDisplayMode.RunnerOffset:
                    currentOffset = runnerOffset;
                    break;
                case OffsetDisplayMode.LevelEndOffset:
                    currentOffset = levelEndOffset;
                    break;
                case OffsetDisplayMode.VerticalPlatformOffset:
                    currentOffset = verticalPlatformOffset;
                    break;
            }

            if (currentOffset.Target == null) return;

            transform.position = currentOffset.Target.position;
            cameraSwipeScript.transform.localPosition = currentOffset.PositionOffset;
            cameraSwipeScript.transform.localEulerAngles = currentOffset.RotationOffset;
        }

        private void Awake()
        {
            followScript = GetComponent<CameraFollowForward>();
        }

        private void OnEnable()
        {
            StaticEvents.addCameraOffset += OnCameraOffsetChange;
            StaticEvents.onPathEnded += OnPathEnded;
            StaticEvents.onVerticalPlatformReached += OnVerticalPlatformReached;
        }

        private void OnDisable()
        {
            StaticEvents.addCameraOffset -= OnCameraOffsetChange;
            StaticEvents.onPathEnded -= OnPathEnded;
            StaticEvents.onVerticalPlatformReached -= OnVerticalPlatformReached;
        }
        #endregion

        #region ENUMS
        private enum OffsetDisplayMode
        {
            RunnerOffset,
            LevelEndOffset,
            VerticalPlatformOffset
        }
        #endregion
    }
}