using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevRunner.Camera
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform followTarget;
        [SerializeField] private Transform lookAtTarget;
        [SerializeField] private float moveSpeed = 10f;
        [SerializeField] private Vector3 offset;
        [SerializeField] private bool lookAt;

        [Header("Level End")]
        [SerializeField] private Vector3 endLevelOffset;
        [SerializeField] private float leMoveSpeed;
        private bool levelEnd;

        private void FixedUpdate()
        {
            MoveCamera();
        }

        private void MoveCamera()
        {
            if (levelEnd)
            {
                LevelEnd();
                return;
            }

            Vector3 step = followTarget.TransformPoint(offset);
            transform.position = Vector3.Lerp(transform.position, step, moveSpeed * Time.fixedDeltaTime);

            if (lookAt && lookAtTarget != null)
                transform.LookAt(lookAtTarget);
        }

        float turnSmoothVelocity;
        private void LevelEnd()
        {
            Vector3 step = followTarget.position + endLevelOffset;
            transform.position = Vector3.Lerp(transform.position, step, leMoveSpeed * Time.fixedDeltaTime);

            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, 0, ref turnSmoothVelocity, 1f);
            var eulerAngle = Quaternion.Euler(smoothAngle, 0f, 0f);
            transform.rotation = eulerAngle;
        }

        private void LevelEndStarted()
        {
            levelEnd = true;
        }
    }
}