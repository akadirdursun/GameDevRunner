using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevRunner.Movement
{
    public class SwipeController : MonoBehaviour
    {
        #region Mine
        [SerializeField] private float dragSpeed;
        [SerializeField] private float dragLimit = 4f;

        private Vector3 firstPos;
        private Vector3 lastPos;
        private Vector3 currentSwipe;

        private void FixedUpdate()
        {
            Swipe();
            Rotation();
        }

        private void Swipe()
        {
            if (!Input.GetMouseButtonDown(0) && !Input.GetMouseButton(0))
            {
                currentSwipe.x = 0;
            }

            if (Input.GetMouseButtonDown(0))
            {
                firstPos = Input.mousePosition;
            }
            if (Input.GetMouseButton(0))
            {
                lastPos = Input.mousePosition;

                currentSwipe = (lastPos - firstPos);
                Vector3 SwipeCurrent = currentSwipe;
                currentSwipe = currentSwipe.normalized;

                transform.localPosition = new Vector3(Mathf.Clamp(transform.localPosition.x, -dragLimit, dragLimit), transform.localPosition.y, transform.localPosition.z);

                if (firstPos.x != lastPos.x)
                {
                    transform.localPosition += transform.right * dragSpeed * SwipeCurrent.x * 0.1f * Time.fixedDeltaTime;
                }
                firstPos = lastPos;
            }
        }

        private void Rotation()
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), 5 * Time.fixedDeltaTime);
        }
        #endregion
    }
}