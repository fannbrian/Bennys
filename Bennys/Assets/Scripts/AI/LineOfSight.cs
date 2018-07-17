using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Bennys
{
    /// <summary>
    /// Handles player detection by enemy AI.
    /// 
    /// Brian Fann
    /// 7/16/18
    /// </summary>
    [ExecuteInEditMode]
    public class LineOfSight : MonoBehaviour
    {
        public float viewRadius;
        [Range(0, 360)]
        public float viewAngle;

        public LayerMask targetMask;
        public LayerMask obstacleMask;

        public NavMeshAgent agent;

        public Vector3 Facing
        {
            get
            {
                if (agent.velocity.magnitude > 0)
                {
                    _facing = agent.velocity.normalized;
                }

                return _facing;
            }
        }

        private Vector3 _facing;

        public List<Transform> visibleTargets = new List<Transform>();

        private void Start()
        {
            StartCoroutine("FindTargetWithDelay", .2f);
            agent = GetComponent<NavMeshAgent>();
        }

        IEnumerator FindTargetWithDelay(float delay)
        {
            while (true)
            {
                yield return new WaitForSeconds(delay);
                FindVisibleTargets();
            }
        }

        void FindVisibleTargets()
        {
            visibleTargets.Clear();
            var targets = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

            for (int i = 0; i < targets.Length; i++)
            {
                var target = targets[i].transform;
                var dirToTarget = (target.position - transform.position).normalized;

                if (Vector3.Angle(Facing, dirToTarget) < viewAngle / 2)
                {
                    var distance = Vector3.Distance(transform.position, target.position);

                    if (!Physics.Raycast(transform.position, dirToTarget, distance, obstacleMask))
                    {
                        visibleTargets.Add(target);
                    }
                }
            }
        }

        public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
        {
            if (!angleIsGlobal)
            {
                var facing = Facing;
                angleInDegrees += Mathf.Atan2(facing.x, facing.z) * Mathf.Rad2Deg;
            }

            var x = Mathf.Sin(angleInDegrees * Mathf.Deg2Rad);
            var z = Mathf.Cos(angleInDegrees * Mathf.Deg2Rad);

            return new Vector3(x, 0, z);
        }
    }
}