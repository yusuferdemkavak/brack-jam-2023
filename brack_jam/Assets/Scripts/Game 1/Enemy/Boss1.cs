using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss1 : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnersManager;
    public GameObject gameEndingManager;
    public float health = 75f;
    public GameObject deathEffect;
    public GameObject bossHealthBar;
    public Slider bossHealthBarFiller;

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, GameObject.Find("Player").transform.position, 1.5f * Time.deltaTime);
        bossHealthBarFiller.value = health;
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
        bossHealthBar.SetActive(false);
        player.tag = "Winner";
        Destroy(spawnersManager);
        gameEndingManager.GetComponent<EndingManager>().EndGame();
        Destroy(gameObject);
    }
}
