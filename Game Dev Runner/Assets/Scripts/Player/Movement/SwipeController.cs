using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevRunner.Movement
{
    public class SwipeController : BaseMovement
    {
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float moveLimit = 4f;

        private float firstPos;
        private float lastPos;
        private float targetPos;

        protected override void Move()
        {
            Vector3 position = transform.localPosition;
            position.x = Mathf.Lerp(position.x, targetPos * moveLimit, moveSpeed * Time.deltaTime);
            transform.localPosition = position;
        }

        protected override void GetInput()
        {
            if (Input.GetMouseButtonDown(0))
            {
                firstPos = Input.mousePosition.x;
                canMove = true;
            }
            else if (Input.GetMouseButton(0) && (firstPos != Input.mousePosition.x))
            {
                lastPos = Input.mousePosition.x;

                targetPos = Mathf.Clamp((lastPos - firstPos), -1, 1);
                firstPos = lastPos;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                canMove = false;
            }
        }
    }
}