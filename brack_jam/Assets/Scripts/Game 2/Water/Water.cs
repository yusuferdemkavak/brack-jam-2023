using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnPoint;
    public AudioClip deathSound;
    public GameObject MainCamera;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.tag == "Player")
        {
            StartCoroutine(Respawn());
        }
    }

    public IEnumerator Respawn()
    {
        player.GetComponent<PlayerHealth2>().TakeDamage(1f);
        AudioSource.PlayClipAtPoint(deathSound, MainCamera.transform.position);
        player.SetActive(false);
        yield return new WaitForSeconds(1f);
        player.transform.position = spawnPoint.transform.position;
        player.SetActive(true);
    }
}
