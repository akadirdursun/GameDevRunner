using PathCreation;
using UnityEngine;

namespace GameDevRunner.Movement
{
    public class MoveForward : BaseMovement
    {
        [SerializeField] private PathCreator pathCreator;
        [SerializeField] private float moveSpeed = 5;

        private float distanceTravelled;        

        #region MonoBehaviour METHODS
        private void Start()
        {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }
        #endregion

        protected override void Move()
        {
            distanceTravelled += moveSpeed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, EndOfPathInstruction.Stop);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, EndOfPathInstruction.Stop);

            if (pathCreator.path.PathEnded(distanceTravelled))
            {
                PathEnds();
            }
        }

        private void PathEnds()
        {
            StaticEvents.onPathEnded?.Invoke();
            this.enabled = false;
        }
    }
}