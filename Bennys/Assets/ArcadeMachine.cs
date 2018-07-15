using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeMachine : MonoBehaviour,IInteractable {
    PlayerMoney money;
	// Use this for initialization
	void Start () {
        money = FindObjectOfType<PlayerMoney>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
   public void OnInteraction()
    {
        money.Money += 5;
    }
}
