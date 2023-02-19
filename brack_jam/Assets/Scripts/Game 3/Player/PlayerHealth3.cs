using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth3 : MonoBehaviour
{
    public int health = 3; 

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
