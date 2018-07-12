using UnityEngine;
using UnityEngine.AI;
public class LineOfSightVisual : MonoBehaviour {
    public float DetectionAngle;
    NavMeshAgent _agent;
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void OnDrawGizmosSelected()
    {
        if (_agent == null) return;

        var facing = _agent.velocity.normalized;
        var angle = Mathf.Atan2(facing.z, facing.x);
        var angle1 = angle + DetectionAngle * Mathf.Deg2Rad;
        var angle2 = angle - DetectionAngle * Mathf.Deg2Rad;
        var dir1 = new Vector3(Mathf.Cos(angle1), Mathf.Sin(angle1));
        var dir2 = new Vector3(Mathf.Cos(angle2), Mathf.Sin(angle2));

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, dir1 * 100f);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, dir2 * 100f);
    }
}
