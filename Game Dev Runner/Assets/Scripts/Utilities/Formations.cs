using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevRunner
{
    public static class Formations
    {
        public static List<Vector3> GetCirclePositions(int positionCount, float distanceOnFormation)
        {
            List<Vector3> spawnPositions = new List<Vector3>();
            float radius = distanceOnFormation;
            for (int i = 0; i < positionCount; i++)
            {
                if (i != 0 && i % 10 == 0)
                    radius += distanceOnFormation;

                float angle = (3.14f * 2 / 10) * i;
                float x = Mathf.Cos(angle) * radius;
                float z = Mathf.Sin(angle) * radius;
                Vector3 spawnPos = new Vector3(x, 0f, z);
                spawnPositions.Add(spawnPos);
            }

            return spawnPositions;
        }

        public static List<Vector3> GetSquarePositions(int positionCount, float distanceOnFormation)
        {
            List<Vector3> spawnPositions = new List<Vector3>();

            int countOnLine = (int)Mathf.Sqrt(positionCount);
            float startXPos = -(countOnLine / 2) * distanceOnFormation;
            float zPos = startXPos;

            for (int z = 0; z <= countOnLine; z++)
            {
                for (int x = 0; x < countOnLine; x++)
                {
                    spawnPositions.Add(new Vector3((startXPos + (x * distanceOnFormation)), 0f, zPos));
                    if (spawnPositions.Count == positionCount)
                        break;
                }
                if (spawnPositions.Count == positionCount)
                    break;

                zPos += distanceOnFormation;
            }

            return spawnPositions;
        }

        public static List<Vector3> GetRandomPositions(int positionCount, float distanceOnFormation, int multiplier = 2)
        {
            List<Vector3> availablePositions = GetSquarePositions(positionCount * multiplier, distanceOnFormation);
            List<Vector3> selectedPositions = new List<Vector3>();
            for (int i = 0; i < positionCount; i++)
            {
                int rs = Random.Range(0, availablePositions.Count);
                selectedPositions.Add(availablePositions[rs]);
                availablePositions.RemoveAt(rs);
            }

            return selectedPositions;
        }
    }
}