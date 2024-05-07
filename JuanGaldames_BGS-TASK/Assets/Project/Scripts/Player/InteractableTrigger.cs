using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableTrigger : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] PlayerInteract playerInteract;
    private void Update()
    {
        transform.localPosition = playerMovement.LastDirection * 0.25f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerInteract.Interactables.Add(collision.gameObject);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        playerInteract.Interactables.Remove(collision.gameObject);
    }
}
