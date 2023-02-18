using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFireBuff : MonoBehaviour
{
    public GameObject player;
    public float buffDuration;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Destroy(gameObject, 15f);
    }

    void Update()
    {
        if (buffDuration > 0)
        {
            buffDuration -= 1 * Time.deltaTime;
            if (buffDuration <= 0)
            {
                player.GetComponent<Shooting>().fireRate = 0.3f;
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            player.GetComponent<Shooting>().fireRate = 0.2f;
            buffDuration = 5f;
        }
    }

}
