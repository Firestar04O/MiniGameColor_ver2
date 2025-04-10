using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymovement : MonoBehaviour
{
    public Player player;
    Rigidbody2D enemyrgbd;
    SpriteRenderer enemyspriteRenderer;
    public int enemyvelocity;
    private int direction;
    public int maximumdistance;
    public int minimumdistance;
    private float value;
    public bool stop;
    void Awake()
    {
        stop = false;
        enemyrgbd = GetComponent<Rigidbody2D>();
        enemyspriteRenderer = GetComponent<SpriteRenderer>();
        direction = 1;
        value = enemyrgbd.velocity.x;
    }
    private void OnEnable()
    {
        ButtonController.Onstopping += VerifyColor;
    }
    private void OnDisable()
    {
        ButtonController.Onstopping -= VerifyColor;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameObject.tag == "KindEarth")
        {
            if (!stop)
            {
                enemyrgbd.velocity = new Vector2(enemyvelocity * direction, -2.64225f);
            }
            else
            {
                enemyrgbd.velocity = new Vector2(0, 0);
            }
            if (gameObject.transform.position.x >= maximumdistance)
            {
                direction = -1;
            }
            else if (gameObject.transform.position.x <= minimumdistance)
            {
                direction = 1;
            }
        }
        else if (gameObject.tag == "KindAir")
        {
            if (!stop)
            {
                enemyrgbd.velocity = new Vector2(value, enemyvelocity * direction);
            }
            else
            {
                enemyrgbd.velocity = new Vector2(0, 0);
            }
            if (gameObject.transform.position.y >= maximumdistance)
            {
                direction = -1;
            }
            else if (gameObject.transform.position.y <= minimumdistance)
            {
                direction = 1;
            }
        }
    }
    public void VerifyColor()
    {
        if(enemyspriteRenderer.color == player.myspriteRenderer.color)
        {
            stop = true;
        }
    }
}
