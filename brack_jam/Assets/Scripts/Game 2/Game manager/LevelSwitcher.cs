using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSwitcher : MonoBehaviour
{
    public int coins = 0;
    public int level = 1;

    void Start()
    {
        
    }

    void Update()
    {
        if (coins == 3 + level * 2)
        {
            level++;
            coins = 0;
        }
    }
}
