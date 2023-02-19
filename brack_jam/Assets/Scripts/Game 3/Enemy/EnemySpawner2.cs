using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner2 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public EnemiesManager enemiesManager;
    public int Horizontalqueue;
    public int Verticalqueue;
    void Start()
    {
        SpawnEnemy();
    }

    void Update()
    {
        
    }

    public void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
        enemiesManager.spawnersListList.spawnersList[Horizontalqueue].lists[Verticalqueue] = enemy;
    }
}
