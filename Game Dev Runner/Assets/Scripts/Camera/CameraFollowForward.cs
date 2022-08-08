using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevRunner.CameraControlls
{
    public class CameraFollowForward : MonoBehaviour
    {
        [SerializeField] private Transform target;

        public Transform Target { set => target = value; }

        #region MonoBehaviour METHODS
        private void LateUpdate()
        {
            Movement();
            Rotation();
        }
        #endregion

        private void Movement()
        {
            if (target == null) return;
            transform.position = target.position;
        }

        private void Rotation()
        {
            if (target == null) return;
            transform.rotation = target.rotation;
        }
    }
}