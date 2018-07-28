using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bennys;


public class PlayerController : MonoBehaviour {
    [SerializeField]
    public float movementspeed = 1f;
    Rigidbody rb;
    float horizontal, vertical;
    float heading;
    bool isflipped = false;
    public Vector3 movedirection;
   public  SpriteRenderer render;
    Animator animate;
    void Start()
    {
        animate = render.GetComponent<Animator>();

        rb = GetComponent<Rigidbody>();
       
    }
    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        //movedirection is based on what axis of the keyboard the player is using, i.e WASD or arrow keys 

        animate.SetFloat("Directionup", vertical);
   /*    if(vertical < 0)
        {
           render.flipY = true;
        }
        else
        {
            render.flipY = false;
        }*/
        if(horizontal > 0)
        {
            render.flipX = true;
            isflipped = true;
        }
        else if(horizontal < 0 && isflipped)
        {
            render.flipX = false;
            isflipped = false;
        }


        animate.SetFloat("Directionleft", horizontal);

        movedirection = new Vector3(horizontal, 0f , vertical);
        rb.velocity = movedirection * movementspeed;
        animate.SetFloat("Velocity", rb.velocity.magnitude);
        //if the player is moving a certain direction, they will rotate to that direction
        //heading = Mathf.Atan2(-horizontal, vertical);
        if (movedirection.magnitude > 0.1)
          {
            //transform.rotation = Quaternion.Euler(0f, 0f, heading * Mathf.Rad2Deg);
          }
    }
   }

