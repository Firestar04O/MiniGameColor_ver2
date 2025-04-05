using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Playermovement : MonoBehaviour
{
    public UIManager uimanager;
    public int velocity;
    public int jumpforce;
    private float Horizontal;
    private bool jumpPresssed;
    private bool Verifyjump;
    private int count;
    Rigidbody2D myrgbd;

    [Header("Raycast properties")]
    [SerializeField] private Transform _origin;
    [SerializeField] private Vector2 _direction;
    [SerializeField] private float _distance;
    [SerializeField] private LayerMask _layerMask;

    [Header("Draw Properties")]
    [SerializeField] private Color colorColliding = Color.green;
    [SerializeField] private Color colorNotColliding = Color.red;
    private void Awake()
    {
        myrgbd = GetComponent<Rigidbody2D>();
        count = 0;
    }
    private void Update()
    {
        if (uimanager.Invideogame)
        {
            Horizontal = Input.GetAxis("Horizontal");
            _direction = Vector2.down;
            if (Input.GetKeyDown(KeyCode.Space) && Verifyjump || Input.GetKeyDown(KeyCode.Space) && count < 1)
            {
                jumpPresssed = true;
                count++;
            }
            DoRaycast(_direction);
        }
    }
    void FixedUpdate()
    {
        if (uimanager.Invideogame)
        {
            myrgbd.velocity = new Vector2(Horizontal * velocity, myrgbd.velocity.y);
            if (jumpPresssed)
            {
                myrgbd.velocity = new Vector2(myrgbd.velocity.x, jumpforce);
                jumpPresssed = false;
            }
        }
    }
    public void DoRaycast(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(_origin.position, _direction, _distance, _layerMask);

        if(hit.collider != null)
        {
            Debug.DrawRay(_origin.position, _direction * hit.distance, colorColliding);
            Verifyjump = true;
            count = 0;
        }
        else
        {
            Debug.DrawRay(_origin.position, _direction * _distance, colorNotColliding);
            Verifyjump = false;
        }
    }
}
