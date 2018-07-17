
namespace Bennys.PlayMaker.Actions
{
    /// <summary>
    /// Patrol action to move agent between waypoints.
    /// 
    /// Brian Fann
    /// 7/10/18
    /// </summary>
    public class WaypointPatrolAction : BasePatrolAction
    {
        private int _currentDestinationIndex;
        private int _deltaIndex;

        public override void OnEnter()
        {
            base.OnEnter();

            // Set destination to first point.
            _agent.SetDestination(_path.points[_currentDestinationIndex]);
        }

        public override void OnUpdate()
        {
            var detectionAngle = _fsm.FsmVariables.GetFsmFloat("DetectionAngle");

            if (_sight.visibleTargets.Count > 0)
            {
                Fsm.SendEventToFsmOnGameObject(Owner, "", "playerFound");
            }

            // End early if owner hasnt reached destination.
            if (!IsStopped) return;

            // If path is circular, set index to next index (if at end of array, loops back to index 0)
            // E.g. 0 -> 1 -> 2 -> 0 -> 1 -> 2
            if (_path.IsCircular)
            {
                _currentDestinationIndex = ++_currentDestinationIndex % _path.points.Length;
            }
            // If path is not circular, index will decrement after reaching end until it reaches index 0.
            // E.g, 0 -> 1 -> 2 -> 1 -> 2 -> 0
            else
            {
                if (_currentDestinationIndex == 0)
                {
                    _deltaIndex = 1;
                }
                else if (_currentDestinationIndex == _path.points.Length)
                {
                    _deltaIndex = -1;
                }

                _currentDestinationIndex += _deltaIndex;
            }

            // Set NavMesh destination to the next index.
            _agent.SetDestination(_path.points[_currentDestinationIndex]);
        }
    }
}