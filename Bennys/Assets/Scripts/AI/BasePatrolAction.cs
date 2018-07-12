using UnityEngine;
using UnityEngine.AI;
using HutongGames.PlayMaker;

namespace Bennys.PlayMaker.Actions
{
    /// <summary>
    /// Base class for actions that deal with line of sight with the player.
    /// 
    /// Brian Fann
    /// 7/10/18
    /// </summary>
    [ActionCategory(ActionCategory.Character)]
    public class BasePatrolAction : FsmStateAction
    {
        // Cache components
        protected PlayMakerFSM _fsm { get; set; }
        protected PatrolPath _path { get; set; }
        protected NavMeshAgent _agent { get; set; }

        public override void OnEnter()
        {
            base.OnEnter();

            _fsm = Fsm.FsmComponent;
            _path = Owner.GetComponent<PatrolPath>();
            _agent = Owner.GetComponent<NavMeshAgent>();
        }

        public bool IsObjectVisible(GameObject target)
        {
            var origin = Owner;
            var facing = _agent.velocity.normalized;
            var detectionAngle = _fsm.FsmVariables.GetFsmFloat("DetectionAngle").Value;

            if (!IsObjectInCone(origin.transform.position, facing, detectionAngle, target)) return false;

            RaycastHit hit;
            var layerMask = 1 << 8 | 1 << 9;
            var ray = new Ray(origin.transform.position, target.transform.position);

            if (Physics.Raycast(ray, out hit, layerMask))
            {
                if (hit.collider.gameObject == target)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsObjectInCone(Vector3 position, Vector3 facing, float detectionAngle, GameObject obj)
        {
            var direction = obj.transform.position - position;
            var angle = Vector3.Angle(facing, direction);

            return angle <= detectionAngle;
        }
    }
}