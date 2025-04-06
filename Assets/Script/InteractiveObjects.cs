using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObjects : MonoBehaviour
{
    public static event Action OnLootMoney;
    public static event Action OnLootHealth;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && gameObject.tag == "Money")
        {
            OnLootMoney?.Invoke();
        }
        else if (collision.gameObject.tag == "Player" && gameObject.tag == "Health")
        {
            OnLootHealth?.Invoke();
        }
    }
}
