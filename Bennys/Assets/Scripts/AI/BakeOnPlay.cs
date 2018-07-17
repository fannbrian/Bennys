
using UnityEngine;
using UnityEngine.AI;
public class BakeOnPlay : MonoBehaviour {
    public NavMeshSurface surface;
	void Start () {
        surface.BuildNavMesh();
	}
}
