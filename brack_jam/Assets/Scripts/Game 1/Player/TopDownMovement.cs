using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    public float speed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    Vector2 movement;

    void Update()
    {
        float horizontal = 0;
        float vertical = 0;

        if (Input.GetKey(KeyCode.A))
            horizontal = -1;
        else if (Input.GetKey(KeyCode.D))
            horizontal = 1;

        if (Input.GetKey(KeyCode.W))
            vertical = 1;
        else if (Input.GetKey(KeyCode.S))
            vertical = -1;

        Vector2 movement = new Vector2(horizontal, vertical);
        movement *= speed * Time.deltaTime;

        transform.position += new Vector3(movement.x, movement.y, 0f);

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
