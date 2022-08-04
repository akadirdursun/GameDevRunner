using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : BaseMovement
{
    [SerializeField] private PathCreator pathCreator;
    [SerializeField] private float moveSpeed = 5;

    private float distanceTravelled;

    protected override void Move()
    {
        distanceTravelled += moveSpeed * Time.deltaTime;
        transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, EndOfPathInstruction.Stop);
        transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, EndOfPathInstruction.Stop);
    }
}