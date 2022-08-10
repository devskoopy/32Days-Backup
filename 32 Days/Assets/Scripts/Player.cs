using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayerMovement {WASD, Arrow, Both}; // enum for picking movement type

public class Player : MonoBehaviour
{
    [Header("Movement")]

    [SerializeField] private PlayerMovement moveType;
    [SerializeField] private float jumpVelocity = 15f; // jump force
    [SerializeField] private float speed = 5f; // walking speed(or running? idk)
    [SerializeField] private Rigidbody2D rb; // rigidbody 2d
    [SerializeField] private Collider2D collider; // collider
    [HideInInspector] public bool canMove = true;

    [SerializeField] private LayerMask layerMask; // layermask
    private float horizontal = 0; // value(left = -1, right = 1)

    [SerializeField] private AudioManager audio;
    
    [Header("Animations")]
    [SerializeField] private Animator anim1;
    [SerializeField] private Animator anim2;

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            // Flipping the character
            Flip();

            // Player Animation
            HandlePlayerAnimation();

            horizontal = 0;
            if (((Input.GetKey(KeyCode.W) && moveType != PlayerMovement.Arrow) || (Input.GetKey(KeyCode.UpArrow) && moveType != PlayerMovement.WASD) || (Input.GetButton("Jump") && moveType == PlayerMovement.Both)))
            {
                // checks for jump key(corresponding to PlayerMovement enum)
                if (isGrounded())
                {
                    if (anim1.gameObject.active)
                    {
                        anim1.SetTrigger("TakeOf");
                    }
                    if (anim2.gameObject.active)
                    {
                        anim2.SetTrigger("TakeOf");
                    }
                    // Trigger the jump animation
                    rb.velocity = Vector2.up * jumpVelocity;                    
                    audio.Play("jump");
                    // JUMP
                }
            }
            if ((Input.GetKey(KeyCode.RightArrow) && moveType != PlayerMovement.WASD) || (Input.GetKey(KeyCode.D) && moveType != PlayerMovement.Arrow))
            {
                horizontal++;
                // not using Input.GetAxis() since PlayerMovement enum
            }
            if ((Input.GetKey(KeyCode.LeftArrow) && moveType != PlayerMovement.WASD) || (Input.GetKey(KeyCode.A) && moveType != PlayerMovement.Arrow))
            {
                horizontal--;
                // not using Input.GetAxis() since PlayerMovement enum
            }
        }
    }
    
    void FixedUpdate()
    {
        if (canMove)
        {
            rb.velocity = new Vector2(speed * horizontal, rb.velocity.y);
            // constantly change player x direction
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            if (collision.gameObject.GetComponent<DialogueTrigger>() != null)
            {
                canMove = false;
                collision.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
            }
        }
    }
    public void ResetMovement()
    {
        canMove = true;
    }

    bool isGrounded()
    {
        // checks if player is grounded using raycast
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(collider.bounds.center, collider.bounds.size * 0.1f, 0f, Vector2.down, 0.8f, layerMask);
        return raycastHit2d != false; // returns raycast hit(true/false)
    }

    void HandlePlayerAnimation()
    {
        // If the player is not moving then play the idle animation
        if (horizontal == 0)
        {
            // Set "isRunning" bool to false
            if (anim1.gameObject.active)
            {
                anim1.SetBool("isRunning", false);
            }
            if (anim2.gameObject.active)
            {
                anim2.SetBool("isRunning", false);
            }
        }
        else // If the player is moving
        {
            // Set "isRunning" bool to true and play the running animationif (anim1.gameObject.active)
            if (anim1.gameObject.active)
            {
                anim1.SetBool("isRunning", true);
            }
            if (anim2.gameObject.active)
            {
                anim2.SetBool("isRunning", true);
            }
        }

        // Checking if the player is not grounded
        if (!isGrounded())
        {
            if (anim1.gameObject.active)
            {
                anim1.SetBool("isJumping", true);
            }
            if (anim2.gameObject.active)
            {
                anim2.SetBool("isJumping", true);
            }
            // Set "isJumping" bool to true
        }
        else
        {
            if (anim1.gameObject.active)
            {
                anim1.SetBool("isJumping", false);
            }
            if (anim2.gameObject.active)
            {
                anim2.SetBool("isJumping", false);
            }
            if (anim1.gameObject.active)
            {
                anim1.ResetTrigger("TakeOf");
            }
            if (anim2.gameObject.active)
            {
                anim2.ResetTrigger("TakeOf");
            }
        }
    }
    
    void Flip()
    {
        if (horizontal == 1)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else if (horizontal == -1)
        {
            transform.eulerAngles = new Vector3(0, 180f, 0);
        }
    }
    
}
