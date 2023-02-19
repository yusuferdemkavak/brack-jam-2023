using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss3 : MonoBehaviour
{
    public int health = 50;
    public GameObject bossHealthBar;
    public GameObject bulletPrefab;
    public GameObject firePoint;
    public Transform player; 

    void Start()
    {
        
    }

    void Update()
    {
        firePoint.transform.up = player.position - transform.position;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        bossHealthBar.SetActive(false);
        Destroy(gameObject);
    }

    public IEnumerator Attack()
    {
        yield return new WaitForSeconds(1.5f);
        Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
    }
}
