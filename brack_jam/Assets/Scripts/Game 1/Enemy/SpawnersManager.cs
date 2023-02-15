using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnersManager : MonoBehaviour
{
    public GameObject[] spawners;
    public GameObject[] trees;
    public Boss boss;
    public Text timerText;
    public int secondsLeft = 30;
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

        if (wavecount == 3)
        {
            boss.gameObject.SetActive(true);
           for (int k = 0; k < spawners.Length; k++)
            {
                trees[k].SetActive(false);
                Destroy(timerText);
            }
        }

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
                secondsLeft = 30;
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
                for (int k = 0; k < spawners.Length; k++)
                {
                    spawners[k].SetActive(false);
                }
                breakTime = true;
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
