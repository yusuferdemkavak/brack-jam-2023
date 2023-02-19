using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public EnemiesManager enemiesManager;
    public GameObject bulletPrefab;
    public GameObject shootingEnemy;
    public int shootingDelay;
    public int i;
    public int j;
    public int k;

    void Start()
    {
        k = Random.Range(0, enemiesManager.weaponedEnemies.Count);
        shootingDelay = Random.Range(i, j);
        StartCoroutine(Shooting());
    }

    void Update()
    {
        shootingEnemy = enemiesManager.weaponedEnemies[k];

    }

    public IEnumerator Shooting()
    {
        yield return new WaitForSeconds(shootingDelay);
        Instantiate(bulletPrefab, shootingEnemy.transform.position, Quaternion.identity  * Quaternion.Euler(0, 0, -90));
        k = Random.Range(0, enemiesManager.weaponedEnemies.Count);
        shootingDelay = Random.Range(i, j);
        StartCoroutine(Shooting());
    }
}
