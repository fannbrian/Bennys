using UnityEngine;
using UnityEngine.AI;

namespace Bennys
{
    /// <summary>
    /// Utility script for making the attached NavMeshSurface bake upon play.
    /// 
    /// Brian Fann
    /// 7/16/18
    /// </summary>
    [RequireComponent(typeof(NavMeshSurface))]
    public class BakeOnPlay : MonoBehaviour
    {
        public NavMeshSurface surface;

        void Start()
        {
            surface.BuildNavMesh();
        }
    }
}