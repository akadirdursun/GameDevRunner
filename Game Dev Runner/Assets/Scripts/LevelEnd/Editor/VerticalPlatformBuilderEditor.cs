using UnityEditor;
using UnityEngine;

namespace GameDevRunner.LevelEnd
{
    [CustomEditor(typeof(VerticalPlatformBuilder))]
    public class VerticalPlatformBuilderEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            VerticalPlatformBuilder platformBuilder = (VerticalPlatformBuilder)target;

            if (GUILayout.Button("Build"))
            {
                platformBuilder.Build();
            }

            if (GUILayout.Button("Clear"))
            {
                platformBuilder.Clear();
            }
        }
    }
}