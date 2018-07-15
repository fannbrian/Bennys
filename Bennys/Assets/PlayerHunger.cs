﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerHunger : MonoBehaviour { //keeps track of the main player's hunger
    public event Action OnDeath = delegate { };
    private bool mIsDead = false;
    private float mcurrentHunger = 30f;
    public float Hunger {
        get{
            return mcurrentHunger; 
            }
        set
        {
            if(mcurrentHunger <= 0)
            {
                value = 0;
            }
            else
            {
                mcurrentHunger = value;
            }
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

    public float McurrentHunger
    {
        get
        {
            return mcurrentHunger;
        }

        set
        {
            mcurrentHunger = value;
        }
    }

    public void ChangeHunger()
    {
        if (mIsDead) return;


    }
    void Update()
    {
        if(mcurrentHunger <= 0)
        {
            mIsDead = true;
        }


        if (mIsDead)
        {
            OnDeath();
        }
    }

}
