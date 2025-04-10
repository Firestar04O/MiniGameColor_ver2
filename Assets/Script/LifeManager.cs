using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    Player player;
    public static event Action OnVictory;
    public static event Action OnDefeat;
    void Update()
    {
        if (player.Result == true)
        {
            if (player.currentHealth > 0)
            {
                OnVictory?.Invoke();
            }
            else
            {
                OnDefeat?.Invoke();
            }
            
        }
    }
}
