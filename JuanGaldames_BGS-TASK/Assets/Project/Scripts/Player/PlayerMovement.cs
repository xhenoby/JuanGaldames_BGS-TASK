using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Animator bodieAnimator;
    [SerializeField] Animator clothAnimator;
    [SerializeField] Animator hairAnimator;
    [SerializeField] Animator hatAnimator;
    [SerializeField] Rigidbody2D rb2d;

    bool isBlocked;    
    Vector2 lastDirection;

    public Vector2 LastDirection
    {
        get => lastDirection;
    }

    public void OnMove(InputValue inputValue)
    {
        if (isBlocked) return;

        rb2d.velocity = inputValue.Get<Vector2>();

        if (rb2d.velocity != Vector2.zero)
        {
            lastDirection = rb2d.velocity;
        }

        SetAnimations();
    }

    void SetAnimations()
    {
        bodieAnimator.SetFloat("Velocity", rb2d.velocity.magnitude);
        clothAnimator.SetFloat("Velocity", rb2d.velocity.magnitude);
        hairAnimator.SetFloat("Velocity", rb2d.velocity.magnitude);
        hatAnimator.SetFloat("Velocity", rb2d.velocity.magnitude);

        bodieAnimator.SetFloat("XDirection", lastDirection.x);
        bodieAnimator.SetFloat("YDirection", lastDirection.y);
        
        clothAnimator.SetFloat("XDirection", lastDirection.x);
        clothAnimator.SetFloat("YDirection", lastDirection.y);
        
        hairAnimator.SetFloat("XDirection", lastDirection.x);
        hairAnimator.SetFloat("YDirection", lastDirection.y);
        
        hatAnimator.SetFloat("XDirection", lastDirection.x);
        hatAnimator.SetFloat("YDirection", lastDirection.y);
    }
    public void BlockMovement(bool isBlocked)
    {
        this.isBlocked = isBlocked;
        rb2d.velocity = Vector2.zero;
        SetAnimations();
    }
}
