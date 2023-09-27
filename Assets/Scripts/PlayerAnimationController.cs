using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Set animator parameters based on input keys
        animator.SetBool("IsShooting", Input.GetKey(KeyCode.Space));
        animator.SetBool("IsJumping", Input.GetKey(KeyCode.W));
        animator.SetBool("IsWalking", Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D));
        //animator.SetBool("PlayerCrouch", Input.GetKey(KeyCode.S));

        // If none of the input keys are pressed, play the idle animation
        if (!Input.anyKey)
        {
            animator.SetBool("IsIdle", true);
        }
        else
        {
            animator.SetBool("IsIdle", false);
        }
    }
}
