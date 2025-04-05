using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemymovement : MonoBehaviour
{
    Rigidbody2D enemyrgbd;
    public int enemyvelocity;
    private int direction;
    public int maximumdistance;
    public int minimumdistance;
    private float value;
    void Awake()
    {
        enemyrgbd = GetComponent<Rigidbody2D>();
        direction = 1;
        value = enemyrgbd.velocity.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(gameObject.tag == "KindEarth")
        {
            enemyrgbd.velocity = new Vector2(enemyvelocity * direction, -2.64225f);
            if (gameObject.transform.position.x >= maximumdistance)
            {
                direction = -1;
            }
            else if (gameObject.transform.position.x <= minimumdistance)
            {
                direction = 1;
            }
        }
        else if(gameObject.tag == "KindAir")
        {
            enemyrgbd.velocity = new Vector2(value, enemyvelocity * direction);
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
}
