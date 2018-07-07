using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This interface will make hooking up interactions to player actions a hell of a lot easier
public interface IInteractable {
    void OnInteraction();
}
