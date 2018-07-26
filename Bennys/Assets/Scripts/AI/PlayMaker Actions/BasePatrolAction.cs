using UnityEngine.AI;
using HutongGames.PlayMaker;

namespace Bennys.PlayMaker.Actions
{
    /// <summary>
    /// Base class for actions that deal with line of sight with the player.
    /// 
    /// Brian Fann
    /// 7/16/18
    /// </summary>
    [ActionCategory(ActionCategory.Character)]
    public class BasePatrolAction : FsmStateAction
    {
        // Cache components
        protected PlayMakerFSM _fsm { get; set; }
        protected PatrolPath _path { get; set; }
        protected LineOfSight _sight { get; set; }
        protected NavMeshAgent _agent { get; set; }
        protected AgentSpeed _speed { get; set; }

        public bool IsStopped {
            get
            {
                if (_agent.pathPending) return false;
                if (_agent.remainingDistance > _agent.stoppingDistance) return false;
                if (_agent.hasPath && _agent.velocity.sqrMagnitude != 0f) return false;

                return true;
            }
        }

        public override void OnEnter()
        {
            base.OnEnter();

            _fsm = Fsm.FsmComponent;
            _path = Owner.GetComponent<PatrolPath>();
            _sight = Owner.GetComponent<LineOfSight>();
            _agent = Owner.GetComponent<NavMeshAgent>();
            _speed = Owner.GetComponent<AgentSpeed>();
        }
    }
}