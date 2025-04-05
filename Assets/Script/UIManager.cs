using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Player player;
    public GameObject StartPanel;
    public GameObject VideogamePanel;
    public GameObject ResultPanel;
    public bool Invideogame;
    private void Awake()
    {
        ShowStartPanel();
    }
    public void ShowStartPanel()
    {
        StartPanel.SetActive(true);
        VideogamePanel.SetActive(false);
        ResultPanel.SetActive(false);
        Invideogame = false;
    }
    public void ShowVideogamePanel()
    {
        StartPanel.SetActive(false);
        VideogamePanel.SetActive(true);
        ResultPanel.SetActive(false);
        Invideogame = true;
        player.Reset = true;
    }
    public void ShowResultPanel()
    {
        StartPanel.SetActive(false);
        VideogamePanel.SetActive(false);
        ResultPanel.SetActive(true);
        Invideogame = false;
    }
    public void QuitofmyGame()
    {
        Application.Quit();
    }
}
