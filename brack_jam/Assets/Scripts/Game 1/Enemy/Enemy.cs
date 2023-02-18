using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Sprite[] sprites;
    public GameObject[] buffs;
    public float health = 1f;
    public GameObject player;
    public int buffDropChance;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
        buffDropChance = Random.Range(0, 100);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, 3f * Time.deltaTime);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        if (buffDropChance >= 0 && buffDropChance <= 5)
        {
            Instantiate(buffs[Random.Range(0, buffs.Length)], transform.position, Quaternion.identity);
        }
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerHealth>().TakeDamage(1);
        }
    }
}
