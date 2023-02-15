using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public SpawnersManager spawnersManager;
    public GameObject enemyPrefab;
    void Start()
    {
        StartCoroutine(SpawnEnemy(Random.Range(5, 11)));
    }

    void Update()
    {
        
    }

    public IEnumerator SpawnEnemy(int spawnDelay)
    {
        yield return new WaitForSeconds(spawnDelay);
        Instantiate(enemyPrefab, transform.position, transform.rotation);
        StartCoroutine(SpawnEnemy(Random.Range(spawnersManager.j, spawnersManager.i)));
    }
}
