using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevRunner.Movement
{
    public abstract class BaseMovement : MonoBehaviour
    {
        protected bool canMove = true;

        #region MonoBehaviour METHODS
        private void OnEnable()
        {
            StaticEvents.onPathEnded += OnPathEnded;
        }

        private void OnDisable()
        {
            StaticEvents.onPathEnded -= OnPathEnded;
        }

        private void Update()
        {
            GetInput();
            if (canMove)
            {
                Move();
            }
        }
        #endregion

        #region EVENT LISTENERS
        protected virtual void OnPathEnded()
        {
            canMove = false;
        }
        #endregion

        protected abstract void Move();

        protected virtual void GetInput()
        {

        }
    }
}

