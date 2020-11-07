using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //movement
    Rigidbody2D body;
    float horizontal;
    float vertical;
    public float runSpeed = 5.0f;

    //shoot
    public GameObject bullet;
    public GameObject lysol_canister;
    private Quaternion direction;
    private float shootReady = 0;
    public float bulletCD = 0.15f;
    private float lysolReady = 0;
    public float lysolCD = 5.0f;

    //keybindings
    public KeyCode moveUp;
    public KeyCode moveDown;
    public KeyCode moveLeft;
    public KeyCode moveRight;
    public KeyCode actionShoot;
    public KeyCode actionLysol;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Movement
        if (Input.GetKey(moveUp))
        {
            vertical = 1;
            direction = Quaternion.Euler(0, 0, 90);
        }
        else if (Input.GetKey(moveDown))
        {
            vertical = -1;
            direction = Quaternion.Euler(0, 0, 270);
        }
        else vertical = 0;

        //remove "&& vertical == 0" to allow diagonal movement
        if (Input.GetKey(moveRight) && vertical == 0) 
        {
            horizontal = 1;
            direction = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKey(moveLeft) && vertical == 0)
        {
            horizontal = -1;
            direction = Quaternion.Euler(0, 0, 180);
        }
        else horizontal = 0;

        //Player Actions
        if (Input.GetKey(actionShoot))
        {
            Action("shoot");
        }
        if (Input.GetKeyDown(actionLysol))
        {
            Action("lysol");
        }
    }
    void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    void Action(string action)
    {
        float t = Time.time;

        if (action == "shoot")
        {
            if (shootReady <= t) {
                shootReady = t + bulletCD;
                Instantiate(bullet, this.transform.position, direction);
            } return;
        }
        else if (action == "lysol")
        {
            if (lysolReady <= t) {
                lysolReady = t + lysolCD;
                Instantiate(lysol_canister, this.transform.position, Quaternion.identity);
            }
            return;
        }
    }
}
