using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game2UI : MonoBehaviour
{
    public GameObject pauseMenu;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnClickPause();
        }
    }

    public void OnClickQuit()
    {
        Time.timeScale = 1;
        LoadScene("Main Menu");
    }

    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }

    public void OnClickResume()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
    }

    public void OnClickPause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        else if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
    }

    public void OnClickRestart()
    {
        Time.timeScale = 1;
        LoadScene("Game 2");
    }
}
