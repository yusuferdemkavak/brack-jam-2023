using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject MainCamera;
    public AudioClip gameStartSound;
    public GameObject game1Text;
    public GameObject game2Text;
    public GameObject game3Text;
    public GameObject game1HTP;
    public GameObject game2HTP;
    public GameObject game3HTP;
    public GameObject cloth1;
    public GameObject cloth2;

    void Start()
    {
        
    }

    void Update()
    {
        if (PlayerPrefs.GetInt("Games Finished") == 1)
        {
            cloth1.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Games Finished") == 2)
        {
            cloth1.SetActive(false);
            cloth2.SetActive(false);
        }
    }

    public void OnClickGame1()
    {
        StartCoroutine(LoadScene("Game 1"));
    }

    public void OnClickGame2()
    {
        StartCoroutine(LoadScene("Game 2"));
    }

    public void OnClickGame3()
    {
        StartCoroutine(LoadScene("Game 3"));
    }

    public void OnEnterGame1()
    {
        game1Text.SetActive(false);
        game1HTP.SetActive(true);
    } 

    public void OnExitGame1()
    {
        game1Text.SetActive(true);
        game1HTP.SetActive(false);
    }

    public void OnEnterGame2()
    {
        game2Text.SetActive(false);
        game2HTP.SetActive(true);
    }

    public void OnExitGame2()
    {
        game2Text.SetActive(true);
        game2HTP.SetActive(false);
    }

    public void OnEnterGame3()
    {
        game3Text.SetActive(false);
        game3HTP.SetActive(true);
    }

    public void OnExitGame3()
    {
        game3Text.SetActive(true);
        game3HTP.SetActive(false);
    }

    public IEnumerator LoadScene(string sceneName)
    {
        MainCamera.GetComponent<AudioSource>().enabled = false;
        AudioSource.PlayClipAtPoint(gameStartSound, Camera.main.transform.position);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneName);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    } 

    public void OnClickReset()
    {
        PlayerPrefs.SetInt("Games Finished", 0);
    }
}
