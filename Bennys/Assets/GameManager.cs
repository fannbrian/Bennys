using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
   public PlayerHunger hunger;
    public PlayerMoney money;

	void Awake () {
        if (!hunger)
        {
            hunger = FindObjectOfType<PlayerHunger>();
        }
        if (!money)
        {
            money = FindObjectOfType<PlayerMoney>();
        }
        SetHunger();
        SetMoney();
    }
	void SetHunger()
    {
        hunger.Hunger = 30f;
    }
    void SetMoney()
    {
        money.Money = 20f;
    }
}
