using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner2 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int Horizontalqueue;
    public int Verticalqueue;
    void Start()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
    }

    void Update()
    {
        
    }
}
