using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace GameDevRunner.LevelEnd
{
    public class VerticalPlatformBuilder : MonoBehaviour
    {
        [SerializeField] private PlatformBox partPrefab;
        [Space]
        [SerializeField] private LevelEndMoneyManager moneyScript;
        [SerializeField] private int platformCount;
        [Space]
        [SerializeField] private List<Material> platformMaterials = new List<Material>();
        [SerializeField] private int changeMaterialPer = 1;

        public void Build()
        {
            Clear();
            float moneySize = moneyScript.GetComponentInChildren<MeshRenderer>().bounds.size.y;
            float targetHeight = moneySize * (10 / moneyScript.ValuePerMoney);
            int materialIndex = 0;
            for (int i = 0; i < platformCount; i++)
            {
                PlatformBox part = PrefabUtility.InstantiatePrefab(partPrefab, transform) as PlatformBox;
                part.SetHeight(targetHeight);
                part.SetPotision(i);
                part.SetMaterial(platformMaterials[materialIndex]);

                if (i % changeMaterialPer == 0)
                {
                    materialIndex = (materialIndex + 1) % platformMaterials.Count;
                }
            }
        }

        public void Clear()
        {
            while (transform.childCount > 0)
            {
                DestroyImmediate(transform.GetChild(0).gameObject);
            }
        }
    }
}