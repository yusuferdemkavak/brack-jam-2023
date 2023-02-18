using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnersManager : MonoBehaviour
{
    public GameObject[] spawners;
    public GameObject[] trees;
    public GameObject BossHealthBar;
    public GameObject breakText;
    public Boss1 boss;
    public Text timerText;
    public int secondsLeft = 0;
    public int minutesLeft = 1;
    public int wavecount = 1;
    public bool breakTime = false;
    public int i = 11;
    public int j = 5;

    void Start()
    {
        StartCoroutine(Timer());
    }

    void Update()
    {
        timerText.text = minutesLeft.ToString("00") + ":" + secondsLeft.ToString("00");


        if (minutesLeft > 0 && secondsLeft <= 0)
        {
            minutesLeft--;
            secondsLeft = 59;
        }

        if (secondsLeft == 0 && minutesLeft == 0)
        {
            if (breakTime == true)
            {
                minutesLeft = 1;
                secondsLeft = 0;
                breakText.SetActive(false);
                for (int k = 0; k < spawners.Length; k++)
                {
                    spawners[k].SetActive(true);
                    StartCoroutine(spawners[k].GetComponent<EnemySpawner>().SpawnEnemy(Random.Range(j, i)));
                }
                i -= 2;
                j -= 1;
                wavecount++;
                breakTime = false;
            }
            else
            {
                secondsLeft = 10;
                breakText.SetActive(true);
                for (int k = 0; k < spawners.Length; k++)
                {
                    spawners[k].SetActive(false);
                }
                breakTime = true;
            }

            if (wavecount == 3)
            {
                boss.gameObject.SetActive(true);
                BossHealthBar.SetActive(true);
                Destroy(timerText);
                for (int k = 0; k < spawners.Length/2; k++)
                {
                    Destroy(spawners[k]);
                }
                for (int k = 0; k < trees.Length; k++)
                {
                    Destroy(trees[k]);
                }
            }
        }
    }

        public IEnumerator Timer()
    {
        yield return new WaitForSeconds(1f);
        secondsLeft--;
        StartCoroutine(Timer());
    }
}
