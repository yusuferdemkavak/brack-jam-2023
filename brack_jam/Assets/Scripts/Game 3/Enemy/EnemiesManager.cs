using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    public SpawnersList spawnersListList = new SpawnersList();
    public List<GameObject> weaponedEnemies = new List<GameObject>();
    public GameObject[] enemySpawners;
    public GameObject boss;
    public int kills = 0;
    public int waveCount = 0;


    void Start()
    {
        
    }

    void Update()
    {
        weaponedEnemies[0] = spawnersListList.spawnersList[0].lists[0];
        weaponedEnemies[1] = spawnersListList.spawnersList[1].lists[0];
        weaponedEnemies[2] = spawnersListList.spawnersList[2].lists[0];
        weaponedEnemies[3] = spawnersListList.spawnersList[3].lists[0];
        weaponedEnemies[4] = spawnersListList.spawnersList[4].lists[0];
        weaponedEnemies[5] = spawnersListList.spawnersList[5].lists[0];

        for (int i = 0; i < spawnersListList.spawnersList.Count; i++)
        {
            if (spawnersListList.spawnersList[i].lists[0] == null)
            {
                spawnersListList.spawnersList[i].lists.RemoveAt(0);
            }
        }

        if (kills == 30 && waveCount < 2)
        {
            for (int i = 0; i < enemySpawners.Length; i++)
            {
                enemySpawners[i].GetComponent<EnemySpawner2>().SpawnEnemy();
            }
            waveCount++;
            kills = 0;
        }

        if (waveCount == 2)
        {
            boss.SetActive(true);
            for (int i = 0; i < enemySpawners.Length; i++)
            {
                enemySpawners[i].SetActive(false);
            }
        }
    }
}

[System.Serializable]
public class Spawners
{
    public List<GameObject> lists;
}

[System.Serializable]
public class SpawnersList
{
    public List<Spawners> spawnersList;
}
