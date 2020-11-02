using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //movement
    public float walkSpeed;
    private Vector3 currentPos;
    private Vector3 xPan;
    private Vector3 yPan;

    //shoot
    public float shootSpeed;
    public GameObject bullet;
    public GameObject lysol_canister;
    private Quaternion direction;

    void Start()
    {
        if (walkSpeed == 0) { walkSpeed = 5; } //default value
        currentPos = this.gameObject.transform.position;
        xPan = new Vector3(1, 0, 0);
        yPan = new Vector3(0, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = currentPos;
        //Debug.Log(this.transform.position);

        //Movement
        if (Input.GetKey(KeyCode.W))
        {
            currentPos = Vector3.MoveTowards(currentPos, currentPos += yPan, (walkSpeed * Time.deltaTime));
            direction = Quaternion.Euler(0, 0, 90);
        }
        if (Input.GetKey(KeyCode.A))
        {
            currentPos = Vector3.MoveTowards(currentPos, currentPos -= xPan, (walkSpeed * Time.deltaTime));
            direction = Quaternion.Euler(0, 0, 180);
        }
        if (Input.GetKey(KeyCode.S))
        {
            currentPos = Vector3.MoveTowards(currentPos, currentPos -= yPan, (walkSpeed * Time.deltaTime));
            direction = Quaternion.Euler(0, 0, 270);
        }
        if (Input.GetKey(KeyCode.D))
        {
            currentPos = Vector3.MoveTowards(currentPos, currentPos += xPan, (walkSpeed * Time.deltaTime)); 
            direction = Quaternion.Euler(0, 0, 0);
        }

        //Shoot
        if (Input.GetKeyDown(KeyCode.UpArrow)) //TODO change to "GetKey" after implementing a cooldown.
        {
            Shoot("up");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Shoot("left");
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Shoot("down");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Shoot("right");
        }
    }


    void Shoot(string dir)
    {
        if (dir == "up")
        {
            return;
        }
        if (dir == "left")
        {
            return;
        }
        if (dir == "down")
        {
            Instantiate(lysol_canister, this.transform.position, Quaternion.identity);
            return;
        }
        if (dir == "right")
        {
            //TODO set the rotation for other directions.
            Instantiate(bullet, this.transform.position, direction);
            
            return;
        }
    }
}
