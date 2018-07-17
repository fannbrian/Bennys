using UnityEditor;
using UnityEngine;

namespace Bennys
{
    /// <summary>
    /// Custom editor for allowing designers to easily create patrol paths.
    /// 
    /// Brian Fann
    /// 7/6/18
    /// </summary>
    [CustomEditor(typeof(PatrolPath)), CanEditMultipleObjects]
    public class PatrolPathEditor : Editor
    {
        protected virtual void OnSceneGUI()
        {
            PatrolPath path = (PatrolPath)target;

            // Return early if no points
            if (path.points.Length == 0) return;

            // Draw a polyline between all points in the path
            Handles.color = path.pathColor;
            Handles.DrawPolyLine(path.points);

            // Create a position handle for each point in the path.
            for (var i = 0; i < path.points.Length; i++)
            {
                path.points[i] = Handles.PositionHandle(path.points[i], Quaternion.identity);
            }

            EditorUtility.SetDirty(path);
        }
    }
}