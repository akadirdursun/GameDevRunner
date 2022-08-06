using PathCreation;
using UnityEngine;

namespace GameDevRunner.Movement
{
    public class MoveForward : BaseMovement
    {
        [SerializeField] private PathCreator pathCreator;
        [SerializeField] private float moveSpeed = 5;

        private float distanceTravelled;

        #region EVENT LISTENERS
        private void OnPathEnded()
        {
            StaticEvents.onPathEnded?.Invoke();
        }
        #endregion

        #region MonoBehaviour METHODS
        private void OnEnable()
        {
            pathCreator.path.pathEnded += OnPathEnded;
        }

        private void OnDisable()
        {
            pathCreator.path.pathEnded -= OnPathEnded;
        }
        #endregion

        protected override void Move()
        {
            distanceTravelled += moveSpeed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, EndOfPathInstruction.Stop);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, EndOfPathInstruction.Stop);
        }
    }
}