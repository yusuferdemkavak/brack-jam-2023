using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 7f;
    public Rigidbody2D rb;
    public EnemiesManager enemiesManager;

    void Start()
    {
        enemiesManager = FindObjectOfType<EnemiesManager>();
        rb.velocity = transform.right * speed;
        StartCoroutine(DestroyBullet());
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Boss3 boss = hitInfo.GetComponent<Boss3>();

        if (hitInfo.gameObject.tag == "Enemy")
        {
            Destroy(hitInfo.gameObject);
            enemiesManager.kills++;
            Destroy(gameObject);
        }

        if (boss != null)
        {
            boss.TakeDamage(1);
            Destroy(gameObject);
        }

        if(hitInfo.gameObject.tag == "Box")
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
