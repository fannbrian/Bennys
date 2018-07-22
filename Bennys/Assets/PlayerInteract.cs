using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {
    public PlayerController controller;
    IInteractable interact;

    public void Start()
    {
        controller = GetComponent<PlayerController>();
    }

    //This update will draw the raycasthit and check if the player is touching an interactable object
    private void Update()
    {
        //hit = Physics.Raycast(transform.position + new Vector3(0, 0.5f, 0), controller.movedirection, 1f, LayerMask.GetMask("Furniture"));
        var ray = new Ray(transform.position + new Vector3(0, 0.5f, 0), controller.movedirection.normalized);
        Debug.DrawRay(transform.position + new Vector3(0, 0.5f, 0), controller.movedirection.normalized);

        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, 1f))
        {
            interact = hit.collider.GetComponent<Collider>().GetComponent<IInteractable>();

            //If the player is touching an interactable object and presses the space bar, the object will do the interaction
            if (interact != null && Input.GetKeyDown(KeyCode.Space))
            {
                interact.OnInteraction();
                interact = null;
            }
        }
    }
}
