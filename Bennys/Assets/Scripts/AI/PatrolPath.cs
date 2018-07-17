using UnityEngine;

/// <summary>
/// Data structure for a npc's patrol path.
/// </summary>
[ExecuteInEditMode]
public class PatrolPath : MonoBehaviour
{
    [Tooltip("Points in the patrol path.")]
    public Vector3[] points;

    [Tooltip("Once the agent reaches the last point, do they go to the first point?")]
    public bool IsCircular;

    [Tooltip("How big each point appears in the scene view.")]
    public float pointSize = 0.25f;

    [Tooltip("Color of each point in scene view.")]
    public Color pointColor = Color.red;

    [Tooltip("Color of path between points in scene view.")]
    public Color pathColor = Color.red;

    private void OnDrawGizmosSelected()
    {
        // Draw a cube at each point
        foreach(var point in points)
        {
            Gizmos.color = pointColor;
            Gizmos.DrawCube(point, Vector3.one * pointSize);
        }
    }
}