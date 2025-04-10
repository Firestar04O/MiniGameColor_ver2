using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class ButtonController : MonoBehaviour
{
    public static event Action Onstopping;
    public Player player;
    public SpriteRenderer playerspriteRenderer;
    public Button mybutton;
    public int[] buttons;
    public int count;
    private void Awake()
    {
        mybutton = GetComponent<Button>();
        playerspriteRenderer = player.GetComponent<SpriteRenderer>();
        buttons = new int[2];
        //mybutton.onClick.AddListener(ChangePlayerColor);
    }
    public void ChangePlayerColor()
    {
        if (!player.Imcolliding)
        {
            if(count == 0)
            {
                playerspriteRenderer.color = Color.blue;
            }
            else if(count == 1)
            {
                playerspriteRenderer.color = Color.red;
            }
            else if(count == 2)
            {
                playerspriteRenderer.color = Color.green;
            }
            Onstopping?.Invoke();
            //Color buttonColor = GetComponent<Image>().color;  
            //invoakr acá
            //supongo que detener a los enemys de ese color xd lanza evento y que los listeners sean los enemys
        }
    }
    public void OnPressRightButton(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            count++;
            if (count > 3)
            {
                count = 0;
            }
            ChangePlayerColor();
        }
    }
    public void OnPressLeftButton(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            count--;
            if (count < 0)
            {
                count = 2;
            }
            ChangePlayerColor();
        }
    }
}