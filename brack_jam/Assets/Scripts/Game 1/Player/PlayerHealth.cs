using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 3f;
    public GameObject[] hearths;
    public GameObject spawnersManager;
    public GameObject mainCamera;
    public GameObject deathScreen;
    public AudioClip deathSound;
    public int damageTaken;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        hearths[damageTaken].SetActive(false);
        damageTaken++;
        StartCoroutine(Invincibility());
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(spawnersManager);
        deathScreen.SetActive(true);
        AudioSource.PlayClipAtPoint(deathSound, mainCamera.transform.position);
        mainCamera.GetComponent<AudioSource>().enabled = false;
        Destroy(gameObject);
    }

    public IEnumerator Invincibility()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(1f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
    }
}
