using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bennys.PlayMaker.Actions;

public class AlertSpriteActivationHandler : MonoBehaviour {
    public SpriteRenderer sprite;
    ChasePatrolAction chase = new ChasePatrolAction();

    // Use this for initialization
    void Start () {
        sprite.enabled = false;

     
	}
	
	// Update is called once per frame
	void Update () {
    ;
       if (chase.Active)
       {
           sprite.enabled = true;
            Debug.Log("Chasing");
        }
        else
        {
          sprite.enabled = false;
        }
	}
}
