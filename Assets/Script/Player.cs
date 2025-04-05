using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public static event Action OnLootMoney;
    public static event Action OnLootHealth;

    public UIManager uimanager;
    public int maxHealth = 10;
    public int currentscore = 0;
    public int currentHealth;
    public float currenttime;
    public TextMeshProUGUI healthtext;
    public TextMeshProUGUI score;
    public TextMeshProUGUI finalscore;
    public TextMeshProUGUI time;
    public TextMeshProUGUI timerend;
    public TextMeshProUGUI End;
    SpriteRenderer myspriteRenderer;
    public bool Imcolliding;
    public bool Result;
    public string Victory;
    public int FinalTime;
    public int FinalScore;
    public bool Reset;
    private void Awake()
    {
        Imcolliding = false;
        myspriteRenderer = GetComponent<SpriteRenderer>();
        currenttime = 0;
        Result = false;
        Reset = false;
    }
    private void Start()
    {
        currentHealth = maxHealth;
        currentscore = 0;
    }
    private void Update()
    {
        currenttime = Time.deltaTime + currenttime;
        if (currentHealth <= 0)
        {
            transform.position = new Vector2(-7, -3.385f);
            Result = true;
        }
        Updatetext();
        if (Reset)
        {
            ResetLevel();
        }
        if (Result)
        {
            FinalTime = Mathf.FloorToInt(currenttime);
            FinalScore = currentscore;
            if (currentHealth > 0)
            {
                Victory = "Victoria";
            }
            else
            {
                Victory = "Derrota";
            }
            currentHealth = maxHealth;
            Result = false;
            uimanager.ShowResultPanel();
        }
    }
    private void Updatetext()
    {
        healthtext.text = "Vida: " + currentHealth;
        score.text = "Puntaje: " + currentscore;
        finalscore.text = "Puntaje" + FinalScore;
        time.text = "Tiempo: " + Mathf.FloorToInt(currenttime);
        timerend.text = "Tiempo: " + FinalTime;
        End.text = "Final: " + Victory;
    }
    private void ResetLevel()
    {
        currentHealth = maxHealth;
        transform.position = new Vector2(-7, -3.385f);
        currenttime = 0;
        currentscore = 0;
        Reset = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Imcolliding = true;
        if (collision.gameObject.GetComponent<SpriteRenderer>().color != myspriteRenderer.color)
        {
            if (collision.gameObject.tag == "KindEarth" || collision.gameObject.tag == "KindAir" || collision.gameObject.tag == "KindStatic")
            {
                currentHealth--;
            }
        }
        if(collision.gameObject.tag == "Money")
        {
            OnLootMoney?.Invoke();
        }
        else if (collision.gameObject.tag == "Health")
        {
            OnLootHealth?.Invoke();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "KindEarth" || collision.gameObject.tag == "KindAir" || collision.gameObject.tag == "KindStatic")
        {
            Imcolliding = false;
        }
        if(collision.gameObject.tag == "Victory")
        {
            Result = true;
            transform.position = new Vector2(-7, -3.385f);
        }
    }
}
