using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerControls controls;
    float direction = 0 ;

    public float speed = 400;
    public bool isFacingRight = true;


    public float jumpForce = 6.5f;
    bool isGrounded;

    int numberOfJumps = 0 ;

    public Transform groundCheck;
    public LayerMask groundLayer;

    public Rigidbody2D playerRB;

    public Animator animator;


    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();

        controls.Land.Move.performed += ctx =>
        {
            direction = ctx.ReadValue<float>();
        };

        controls.Land.Jump.performed += ctx =>
        {
            Jump();
        };
    }


    
    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.1f, groundLayer);
        animator.SetBool("isGrounded", isGrounded);

        playerRB.velocity = new Vector2(direction * speed * Time.fixedDeltaTime, playerRB.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(direction));


        if(isFacingRight && direction < 0 || !isFacingRight && direction > 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }


    void Jump()
    {
        if (isGrounded)
        {
            numberOfJumps = 0;
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
            AudioManager.instance.Play("FirstJump");
            numberOfJumps++;
        }
        else if (numberOfJumps == 1)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpForce);
            AudioManager.instance.Play("SecondJump");
            numberOfJumps++;
        }
    }
}
