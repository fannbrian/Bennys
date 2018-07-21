using UnityEngine;

namespace Bennys.PlayMaker.Actions
{
    /// <summary>
    /// Patrol action for when an enemy AI has detected player and is chasing player.
    /// 
    /// Brian Fann
    /// 7/10/18
    /// </summary>
    public class ChasePatrolAction : BasePatrolAction
    {
        private Vector3 _lastKnownPosition;

        public override void OnEnter()
        {
            base.OnEnter();

            _lastKnownPosition = PlayerManager.s.player.transform.position;
            _agent.SetDestination(_lastKnownPosition);
        }

        public override void OnUpdate()
        {
            // If player is in line of sight, set position to player.
            if (_sight.visibleTargets.Count > 0)
            {
                _lastKnownPosition = PlayerManager.s.player.transform.position;
                _agent.SetDestination(_lastKnownPosition);
            }
            else
            {
                if (IsStopped || PlayerManager.s.IsGrabbed)
                {
                    Fsm.SendEventToFsmOnGameObject(Owner, "", "playerLost");
                }
            }
        }
    }
}