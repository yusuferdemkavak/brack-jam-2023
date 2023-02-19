using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Raft : MonoBehaviour
{
    public GameObject player;
    public bool isOnRaft;

    void Start()
    {
        
    }

    void Update()
    {
        if (isOnRaft == true)
        {
            player.GetComponent<TopDownMovement>().enabled = false;
            player.GetComponent<Animator>().enabled = false;
            player.transform.position = transform.position;
            gameObject.transform.parent.GetComponent<Animator>().SetBool("IsOnRaft", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Winner")
        {
            isOnRaft = true;
            StartCoroutine(LoadScene("Main Menu"));
        }
    }

    public IEnumerator LoadScene(string sceneName)
    {
        PlayerPrefs.SetInt("Games Finished", PlayerPrefs.GetInt("Games Finished") + 1);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneName);
    }
}
