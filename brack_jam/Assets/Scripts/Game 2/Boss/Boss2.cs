using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 4f * Time.deltaTime);
    }
}
