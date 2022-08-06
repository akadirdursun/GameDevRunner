using System;
using UnityEngine;

namespace GameDevRunner
{
    public static class StaticEvents
    {
        public static Action onPathEnded;

        public static Action<GeneralInfoesSO> generalInfoPost;

        public static Action<Vector3> addCameraOffset;

        public static Action<int> onPointCollected;
    }
}