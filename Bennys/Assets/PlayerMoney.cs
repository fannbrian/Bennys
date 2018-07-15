using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMoney : MonoBehaviour {
    public event Action OnDeath = delegate { };
    public float mcurrentMoney;
    public bool mIsDead = false;
    public float Money
    {
        get
        {
            return mcurrentMoney;
        }
        set
        {
           mcurrentMoney = value;
        }
    }
    public bool IsDead
    {
        get
        {
            return mIsDead;
        }
        set
        {
            mIsDead = value;
        }
    }
    void Update()
    {
        if (mcurrentMoney <= 0)
        {
            mIsDead = true;
        }


        if (mIsDead)
        {
            OnDeath();
        }
    }

}
