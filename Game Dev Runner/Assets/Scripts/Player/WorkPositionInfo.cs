using UnityEngine;

namespace GameDevRunner
{
    [System.Serializable]
    public struct WorkPositionInfo
    {
        [SerializeField] private Vector3 position;
        [SerializeField] private float rotationY;

        public Vector3 Position { get => position; }
        public float RotationY { get => rotationY; }

        public WorkPositionInfo(Vector3 _position,float _rotationY)
        {
            position = _position;
            rotationY = _rotationY;
        }
    }
}