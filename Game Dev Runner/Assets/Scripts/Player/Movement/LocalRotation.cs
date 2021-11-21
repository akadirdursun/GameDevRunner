using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameDevRunner.Movement
{
    public class LocalRotation : MonoBehaviour
    {
        [SerializeField] private Transform PlayerTransform;
        void Update()
        {
            transform.localRotation = PlayerTransform.localRotation;
        }
    }
}