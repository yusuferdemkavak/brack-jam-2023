using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBuff : MonoBehaviour
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
                player.GetComponent<TopDownMovement>().speed = 5;
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.GetComponent<TopDownMovement>().speed = 7;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            buffDuration = 5f;
        }
    }
}
