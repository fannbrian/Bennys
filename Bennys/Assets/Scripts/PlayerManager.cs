using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    public static PlayerManager s;
    public GameObject player;

	void Awake () {
        s = this;
	}
}
