using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowForward : MonoBehaviour
{
    [SerializeField] private Transform target;

    #region MonoBehaviour METHODS
    private void LateUpdate()
    {
        Movement();
    }
    #endregion

    private void Movement()
    {
        if (target == null) return;
        transform.position = target.position;
    }
}