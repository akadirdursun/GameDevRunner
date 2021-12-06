using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevRunner
{
    public class Worktable : MonoBehaviour
    {
        [SerializeField] private List<Transform> characters = new List<Transform>();
        private List<Vector3> positionList = new List<Vector3>();

        private PositionManager positionManager;
        private BoxCollider tableCollider;

        private void Awake()
        {
            positionManager = transform.parent.GetComponentInChildren<PositionManager>();
            tableCollider = GetComponent<BoxCollider>();
        }
        private void Start()
        {
            GetPositions();
        }

        public void AddCharacterToTable(GameObject _character)
        {
            characters.Add(_character.transform);
            _character.GetComponent<Collider>().enabled = false;

            if (!positionManager.EmptySeatAvailable(characters.Count))
                IncreaseTableSize();

            positionManager.ArrangeCharacterSeats(characters);
        }

        private void IncreaseTableSize()
        {
            CameraManager.instance.ChangeOffset(-Vector3.forward);
            Vector3 scale = transform.localScale;
            scale.x++;
            scale.z++;
            transform.localScale = scale;
            GetPositions();
        }

        private void GetPositions()
        {
            positionList.Clear();
            float x = tableCollider.size.x * transform.localScale.x;
            float z = tableCollider.size.z * transform.localScale.z;

            Vector3 origin = new Vector3(tableCollider.bounds.center.x - (x / 2) - 0.5f, 1f, tableCollider.bounds.center.z - (z / 2) - 0.5f);
            for (float i = 1.5f; i < x; i++)
            {
                Vector3 newPos = origin + (Vector3.right * i);
                positionList.Add(newPos);
                newPos += (Vector3.forward * (z + 1));
                positionList.Add(newPos);
            }

            for (float i = 1.5f; i < z; i++)
            {
                Vector3 newPos = origin + (Vector3.forward * i);
                positionList.Add(newPos);
                newPos += (Vector3.right * (x + 1));
                positionList.Add(newPos);
            }

            positionManager.UpdatePositions(positionList);
        }
    }
}