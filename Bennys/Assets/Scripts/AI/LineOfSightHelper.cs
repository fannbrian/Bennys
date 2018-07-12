 using UnityEngine;

public class LineOfSightHelper {
    public static bool IsObjectVisible(GameObject origin, Vector3 facing, float detectionAngle, GameObject target)
    {
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

    public static bool IsObjectInCone(Vector3 position, Vector3 facing, float detectionAngle, GameObject obj)
    {
        var direction = obj.transform.position - position;
        var angle = Vector3.Angle(facing, direction);

        return angle <= detectionAngle;
    }
}
