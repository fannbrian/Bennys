using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableInteraction : MonoBehaviour, IInteractable {
  //  public TableInteraction tableoption;
	// Use this for initialization
	void Start () {
      //  tableoption = GetComponent<TableInteraction>();
     //   tableoption.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
    
	}
   public void OnInteraction()
    {
        Debug.Log("I'm a Table");
     //   tableoption.enabled = true;
    }
}
