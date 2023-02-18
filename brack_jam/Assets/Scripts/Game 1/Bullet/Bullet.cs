using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Enemy enemy;
    public float speed = 20f;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * speed;
        StartCoroutine(DestroyBullet());
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        enemy = hitInfo.GetComponent<Enemy>();
        Boss1 boss = hitInfo.GetComponent<Boss1>();
        if (enemy != null)
        {
            enemy.TakeDamage(1);
            Destroy(gameObject);
        }

        if (boss != null)
        {
            boss.TakeDamage(1);
            Destroy(gameObject);
        }

        if(hitInfo.gameObject.tag == "Tree")
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
