using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowForward : MonoBehaviour
{
    [SerializeField] private Transform target;

    #region MonoBehaviour METHODS
    private void OnValidate()
    {
        if (target == null) return;

        transform.position = target.position;
        transform.rotation = target.rotation;
    }

    private void LateUpdate()
    {
        Movement();
        Rotation();
    }
    #endregion

    private void Movement()
    {
        if (target == null) return;
        transform.position = target.position;
    }

    private void Rotation()
    {
        if (target == null) return;
        transform.rotation = target.rotation;
    }
}