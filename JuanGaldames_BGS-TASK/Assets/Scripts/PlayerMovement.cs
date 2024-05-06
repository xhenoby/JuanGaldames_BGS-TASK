using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Animator bodieAnimator;
    [SerializeField] Animator clothAnimator;
    [SerializeField] Animator hairAnimator;
    [SerializeField] Animator hatAnimator;
    [SerializeField] Rigidbody2D rb2d;

    Vector2 lastDirection;
    public void OnMove(InputValue inputValue)
    {
        rb2d.velocity = inputValue.Get<Vector2>();

        bodieAnimator.SetFloat("Velocity", rb2d.velocity.magnitude);
        
        clothAnimator.SetFloat("Velocity", rb2d.velocity.magnitude);
        
        hairAnimator.SetFloat("Velocity", rb2d.velocity.magnitude);
        
        hatAnimator.SetFloat("Velocity", rb2d.velocity.magnitude);
        
        if (rb2d.velocity != Vector2.zero)
        {
            lastDirection = rb2d.velocity;
        }

        bodieAnimator.SetFloat("XDirection", lastDirection.x);
        bodieAnimator.SetFloat("YDirection", lastDirection.y);

        clothAnimator.SetFloat("XDirection", lastDirection.x);
        clothAnimator.SetFloat("YDirection", lastDirection.y);

        hairAnimator.SetFloat("XDirection", lastDirection.x);
        hairAnimator.SetFloat("YDirection", lastDirection.y);
        
        hatAnimator.SetFloat("XDirection", lastDirection.x);
        hatAnimator.SetFloat("YDirection", lastDirection.y);
    }
}
