using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerMovement2 : MonoBehaviour 
{
    public GameObject spawnPoint;
    public float moveSpeed;
    private float moveDirection;
    public Animator animator;
    public bool facingRight = true;

    void Update () 
    {

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


        if (moveDirection > 0 && !facingRight) {
            Flip();
        } else if (moveDirection < 0 && facingRight) {
            Flip();
        }

        

        animator.SetFloat("Speed", Mathf.Abs(moveDirection));
    }

    void Flip () {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}

