using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Sprite[] sprites;
    public bool moveRight = false;
    public float speed = 10f;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
        StartCoroutine(MoveEnemySideways());
        StartCoroutine(MoveEnemyDown());
    }

    void Update()
    {
        if (moveRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    public IEnumerator MoveEnemySideways()
    {
        yield return new WaitForSeconds(2f);
        moveRight = !moveRight;
        StartCoroutine(MoveEnemySideways());
    }

    public IEnumerator MoveEnemyDown()
    {
        yield return new WaitForSeconds(4f);
        transform.position = new Vector2(transform.position.x, transform.position.y - 0.5f);
        StartCoroutine(MoveEnemyDown());
    }
}
