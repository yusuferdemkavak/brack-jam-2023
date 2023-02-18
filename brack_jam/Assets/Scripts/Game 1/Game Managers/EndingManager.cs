using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingManager : MonoBehaviour
{
    public GameObject Exit;
    public GameObject raft;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void EndGame()
    {
        Exit.SetActive(false);
        raft.SetActive(true);
    } 
}
