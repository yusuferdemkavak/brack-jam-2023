using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
        public GameObject enemyPrefab;

    void Start()
    {
                StartCoroutine(SpawnEnemy(Random.Range(4, 11)));
    }

    IEnumerator SpawnEnemy(int spawnDelay)
    {
        yield return new WaitForSeconds(spawnDelay);
        Instantiate(enemyPrefab, transform.position, transform.rotation);
        StartCoroutine(SpawnEnemy(Random.Range(3, 8)));
    }
}
