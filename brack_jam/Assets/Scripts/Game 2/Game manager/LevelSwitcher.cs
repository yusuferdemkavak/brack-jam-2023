using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitcher : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnPoint;
    public GameObject boss;
    public int coins = 0;
    public int level = 0;
    public GameObject[] environments;
    public GameObject[] grounds;
    public GameObject[] coinsArray;

    void Start()
    {
        
    }

    void Update()
    {
        if (coins == 3 + level * 2)
        {
            level++;
            coins = 0;
            player.transform.position = spawnPoint.transform.position;
            environments[level].SetActive(true);
            environments[level - 1].SetActive(false);
            grounds[level].SetActive(true);
            grounds[level - 1].SetActive(false);
            coinsArray[level].SetActive(true);
            coinsArray[level - 1].SetActive(false);
        }

        if (level == 2)
        {
            boss.SetActive(true);
        }

        if (level == 3)
        {
            PlayerPrefs.SetInt("Games Finished", PlayerPrefs.GetInt("Games Finished") + 1);
            SceneManager.LoadScene("Main Menu");
        }
    }
}
