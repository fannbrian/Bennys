using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DestinationVisual : MonoBehaviour {
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
