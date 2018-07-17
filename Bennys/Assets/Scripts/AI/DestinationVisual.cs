using UnityEngine;
using UnityEngine.AI;

namespace Bennys
{
    /// <summary>
    /// Utility script for showing the current destination of an agent.
    /// 
    /// Brian Fann
    /// 7/16/18
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public class DestinationVisual : MonoBehaviour
    {
        public NavMeshAgent agent;

        public void OnDrawGizmosSelected()
        {
            if (agent == null)
            {
                agent = GetComponent<NavMeshAgent>();
            }
            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(agent.destination, .25f);
        }
    }
}