using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevRunner.CameraControlls
{
    [System.Serializable]
    public class CameraOffsetInfo
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 positionOffset;
        [SerializeField] private Vector3 rotationOffset;

        public Transform Target { get => target; }
        public Vector3 PositionOffset { get => positionOffset; }
        public Vector3 RotationOffset { get => rotationOffset; }
    }
}