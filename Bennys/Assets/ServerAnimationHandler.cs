using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bennys;

public class ServerAnimationHandler : MonoBehaviour {
    LineOfSight line;
    Animator animate;
   public SpriteRenderer sprite;
	// Use this for initialization
	void Start () {
        line = GetComponent<LineOfSight>();
        animate = sprite.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        animate.SetFloat("HorizontalMovement", line.Facing.x);
        if(line.Facing.x > 0)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
	}
}
