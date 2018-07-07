using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {
    IInteractable interact;
    RaycastHit2D hit;
    //This update will draw the raycasthit and check if the player is touching an interactable object
    private void Update()
    {
        hit = Physics2D.Raycast(transform.position, transform.up, 0.3f, LayerMask.GetMask("Furniture"));
        Debug.DrawRay(transform.position, transform.up);

        if (hit.collider != null)
        {
            interact = hit.collider.GetComponent<Collider2D>().GetComponent<IInteractable>();

            //If the player is touching an interactable object and presses the space bar, the object will do the interaction
            if (interact != null && Input.GetKeyDown(KeyCode.Space))
            {
                interact.OnInteraction();
                interact = null;
            }
        }
    }

    

 
}
