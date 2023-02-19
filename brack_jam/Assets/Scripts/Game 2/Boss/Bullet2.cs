using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    void Start()
    {
        rb.velocity = transform.right * speed;
        StartCoroutine(DestroyBullet());
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(hitInfo.gameObject.tag == "Player")
        {
            StartCoroutine(DestroyBullet2());
            hitInfo.gameObject.GetComponent<PlayerHealth2>().TakeDamage(1f);
        }
    }

    public IEnumerator DestroyBullet()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    public IEnumerator DestroyBullet2()
    {
        gameObject.GetComponent<Collider2D>().isTrigger = false;
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
