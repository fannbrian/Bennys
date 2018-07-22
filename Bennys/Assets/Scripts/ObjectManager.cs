using System.Collections.Generic;
using UnityEngine;

namespace Bennys
{
    /// <summary>
    /// Handles optimization of locating objects in the scene.
    /// 
    /// Brian Fann
    /// 7/21/18
    /// </summary>
    public class ObjectManager : MonoBehaviour
    {
        public static ObjectManager s;
        Dictionary<string, GameObject[]> _objects;

        private void Awake()
        {
            s = this;
            _objects = new Dictionary<string, GameObject[]>();
        }

        public GameObject FindClosestObjectWithTag(GameObject origin, string tag)
        {
            var objects = ObjectManager.s.GetGameObjectsWithTag(tag);
            var closestObject = objects[0];
            var closestDistance = 9999999999999f;

            foreach (var obj in objects)
            {
                var distance = Vector3.Distance(obj.transform.position, origin.transform.position);

                if (distance < closestDistance && obj != origin)
                {
                    closestObject = obj;
                    closestDistance = distance;
                }
            }

            return closestObject;
        }

        public GameObject[] GetGameObjectsWithTag(string tag)
        {
            GameObject[] objects;

            if (!_objects.TryGetValue(tag, out objects))
            {
                objects = GameObject.FindGameObjectsWithTag(tag);
                _objects.Add(tag, objects);
            }

            return objects;
        }
    }
}