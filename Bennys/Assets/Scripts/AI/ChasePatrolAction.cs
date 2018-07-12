using UnityEngine;

namespace Bennys.PlayMaker.Actions
{
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
            if (IsObjectVisible(PlayerManager.s.player))
            {
                _lastKnownPosition = PlayerManager.s.player.transform.position;
                _agent.SetDestination(_lastKnownPosition);
            }
            else
            {
                Fsm.SendEventToFsmOnGameObject(Owner, "", "playerLost");
            }
        }
    }
}