using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObjects : MonoBehaviour
{
    public Player player;
    public bool collided = false;
    private void OnEnable()
    {
        Player.OnLootMoney += DissapearObject;
        Player.OnLootMoney += AddScore;
        Player.OnLootHealth += DissapearObject;
        Player.OnLootHealth += AddHealth;
    }
    public void DissapearObject()
    {
        if (collided)
        {
            gameObject.SetActive(false);
        }
    }
    public void AddScore()
    {
        if (collided)
        {
            player.currentscore = player.currentscore + 50;
        }
    }
    public void AddHealth()
    {
        if (collided)
        {
            int newhealth;
            newhealth = player.currentHealth + 1;
            if (newhealth >= 10)
            {
                player.currentHealth = 10;
            }
            else
            {
                player.currentHealth = newhealth;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collided = true;
        }
    }
}
