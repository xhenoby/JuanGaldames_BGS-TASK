using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    [HideInInspector] public List<GameObject> Interactables;

    public void OnInteract(InputValue inputValue)
    {
        if (Interactables.Count > 0)
        {
            Interactables[0].GetComponent<IInteractable>().Interact();
        }
    }
}
