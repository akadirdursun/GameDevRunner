using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseMovement : MonoBehaviour
{
    protected bool canMove = true;

    private void Update()
    {
        GetInput();
        if (canMove)
        {
            Move();
        }
    }

    protected abstract void Move();

    protected virtual void GetInput()
    {

    }
}