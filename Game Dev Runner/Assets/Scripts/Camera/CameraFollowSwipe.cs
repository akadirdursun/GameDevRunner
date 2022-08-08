using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevRunner.CameraControlls
{
    public class CameraFollowSwipe : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [Space]
        [SerializeField] private float moveSpeed;

        private float xOffset;
        #region MonoBehaviour METHODS
        private void Start()
        {
            xOffset = transform.localPosition.x;
        }
        private void LateUpdate()
        {
            Movement();
        }
        #endregion

        private void Movement()
        {
            if (target == null) return;

            Vector3 thisPos = transform.localPosition;
            thisPos.x = Mathf.Lerp(transform.localPosition.x, target.localPosition.x + xOffset, moveSpeed * Time.deltaTime);
            transform.localPosition = thisPos;
        }
    }
}