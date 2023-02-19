using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth2 : MonoBehaviour
{
    public Text healthCounter;
    public float health = 10f;
    public GameObject deathScreen;
    public AudioClip deathSound;
    public GameObject MainCamera;

    void Start()
    {
        
    }

    void Update()
    {
        healthCounter.text = health.ToString();
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
        deathScreen.SetActive(true);
        AudioSource.PlayClipAtPoint(deathSound, MainCamera.transform.position);
        Destroy(gameObject);
    }
}
