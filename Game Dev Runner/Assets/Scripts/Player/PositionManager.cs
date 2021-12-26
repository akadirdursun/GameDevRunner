using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevRunner
{
    public class PositionManager : MonoBehaviour
    {
        private List<Transform> positionList = new List<Transform>();

        public void UpdatePositions(List<WorkPositionInfo> _positions)
        {
            if (_positions.Count <= positionList.Count) return;

            int d = _positions.Count - positionList.Count;

            for (int i = 0; i < d; i++)
            {
                Transform t = new GameObject().transform;
                t.SetParent(transform);
                positionList.Add(t);
            }

            for (int i = 0; i < positionList.Count; i++)
            {
                positionList[i].position = _positions[i].Position;
                positionList[i].rotation = Quaternion.Euler(0f, _positions[i].RotationY, 0f);
                //ArrangeRotation(positionList[i]);
            }
        }

        public bool EmptySeatAvailable(int _Count)
        {
            if (_Count <= positionList.Count) return true;

            return false;
        }

        public void ArrangeCharacterSeats(List<Transform> characterList)
        {
            for (int i = 0; i < characterList.Count; i++)
            {
                characterList[i].SetParent(positionList[i]);
                characterList[i].localPosition = Vector3.zero;
                characterList[i].localEulerAngles = Vector3.zero;
            }
        }

        //private void ArrangeRotation(Transform _transform)
        //{
        //    Vector3 direction = transform.localPosition - _transform.localPosition;
        //    float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        //    _transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);
        //}
    }
}