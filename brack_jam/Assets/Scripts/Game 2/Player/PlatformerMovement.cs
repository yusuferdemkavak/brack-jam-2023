using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovement : MonoBehaviour 
{
    public GameObject spawnPoint;
    public float moveSpeed;
    public float jumpForce;
    private float moveDirection;
    public Animator animator;
    public bool grounded = false;
    public bool facingRight = true;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;

    void Update () 
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

        if (Input.GetKey(KeyCode.A))
        {
            moveDirection = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            moveDirection = 1;
        }
        else
        {
            moveDirection = 0;
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveDirection * moveSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if (Input.GetKeyDown(KeyCode.W) && grounded) 
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce));
        }

        if (moveDirection > 0 && !facingRight) {
            Flip();
        } else if (moveDirection < 0 && facingRight) {
            Flip();
        }

        

        animator.SetFloat("Speed", Mathf.Abs(moveDirection));
        animator.SetBool("IsJumping", !grounded);
    }

    void Flip () {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }     
}

