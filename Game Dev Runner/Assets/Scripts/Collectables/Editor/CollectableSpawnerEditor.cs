using UnityEngine;
using UnityEditor;

namespace GameDevRunner.Collectables
{
    [CustomEditor(typeof(CollectableSpawner))]
    public class CollectableSpawnerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            CollectableSpawner spawner = (CollectableSpawner)target;

            if (GUILayout.Button("Spawn Points"))
            {
                spawner.SpawnPrefabs();
            }

            if (GUILayout.Button("Clear Points"))
            {
                spawner.ClearPrefabs();
            }
        }
    }
}