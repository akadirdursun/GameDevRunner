using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevRunner.Movement
{
    public abstract class BaseMovement : MonoBehaviour
    {
        protected bool canMove;

        #region MonoBehaviour METHODS
        private void OnEnable()
        {
            StaticEvents.onPathEnded += OnPathEnded;
            StaticEvents.levelStarted += OnLevelStarted;
        }

        private void OnDisable()
        {
            StaticEvents.onPathEnded -= OnPathEnded;
            StaticEvents.levelStarted -= OnLevelStarted;
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

        protected virtual void OnLevelStarted()
        {
            canMove = true;
        }
        #endregion

        protected abstract void Move();

        protected virtual void GetInput()
        {

        }
    }
}

