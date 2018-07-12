using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    [SerializeField]
    public float movementspeed = 1f;
    private Rigidbody2D rb;
    float horizontal, vertical;
    float heading;
    public Vector3 movedirection;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        //movedirection is based on what axis of the keyboard the player is using, i.e WASD or arrow keys 
        movedirection = new Vector3(horizontal, vertical ,0f);
        rb.velocity = movedirection * movementspeed;
        //if the player is moving a certain direction, they will rotate to that direction
        heading = Mathf.Atan2(-horizontal, vertical);
        if (movedirection.magnitude > 0.1)
          {
            transform.rotation = Quaternion.Euler(0f, 0f, heading * Mathf.Rad2Deg);
          }
    }
   }

