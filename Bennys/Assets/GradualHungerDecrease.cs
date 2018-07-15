using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradualHungerDecrease : MonoBehaviour {
    public PlayerHunger hunger;
    float seconds;
	// Use this for initialization
	void Start () {
        hunger = FindObjectOfType<PlayerHunger>();
	}
	
	// Update is called once per frame
	void Update () {
        seconds += Time.deltaTime;
        if(seconds > 2.0f)
        {
            hunger.Hunger--;
            seconds = 0;
        }
	}

}
