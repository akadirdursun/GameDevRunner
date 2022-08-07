using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace GameDevRunner.Collectables
{
    public class CollectableSpawner : MonoBehaviour
    {
        #region Enums
        private enum SpawnType
        {
            Square,
            Circle,
            Random
        }
        #endregion

        [SerializeField] private CollectablePoints collectablePrefab;
        [SerializeField] private Transform spawnHolder;
        [Space]
        [SerializeField] private SpawnType spawnType = SpawnType.Square;
        [SerializeField] private int count;
        [SerializeField] private float distanceBetween = 0.5f;

        public void SpawnPrefabs()
        {
            if (collectablePrefab == null || spawnHolder == null) return;

            ClearPrefabs();

            switch (spawnType)
            {
                case SpawnType.Square:
                    SquareSpawn();
                    break;
                case SpawnType.Circle:
                    CircleSpawn();
                    break;
                case SpawnType.Random:
                    RandomSpawn();
                    break;
            }
        }

        public void ClearPrefabs()
        {
            if (spawnHolder == null || spawnHolder.childCount == 0) return;

            while (spawnHolder.childCount > 0)
            {
                DestroyImmediate(spawnHolder.GetChild(0).gameObject);
            }
        }

        private void SquareSpawn()
        {
            List<Vector3> positions = Formations.GetSquarePositions(count, distanceBetween);

            for (int i = 0; i < positions.Count; i++)
            {
                Transform spawnedTransform = (PrefabUtility.InstantiatePrefab(collectablePrefab, spawnHolder) as CollectablePoints).transform;
                spawnedTransform.localPosition = positions[i];
            }
        }

        private void CircleSpawn()
        {
            List<Vector3> positions = Formations.GetCirclePositions(count, distanceBetween);

            for (int i = 0; i < positions.Count; i++)
            {
                Transform spawnedTransform = (PrefabUtility.InstantiatePrefab(collectablePrefab, spawnHolder) as CollectablePoints).transform;
                spawnedTransform.localPosition = positions[i];
            }
        }

        private void RandomSpawn()
        {
            List<Vector3> positions = Formations.GetRandomPositions(count, distanceBetween);

            for (int i = 0; i < positions.Count; i++)
            {
                Transform spawnedTransform = (PrefabUtility.InstantiatePrefab(collectablePrefab, spawnHolder) as CollectablePoints).transform;
                spawnedTransform.localPosition = positions[i];
            }
        }
    }
}