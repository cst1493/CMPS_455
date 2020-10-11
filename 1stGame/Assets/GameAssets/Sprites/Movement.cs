using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    private Vector3 currentPos;
    private Vector3 xPan;
    private Vector3 yPan;

    void Start()
    {
        if (speed == 0) { speed = 5; } //default value
        currentPos = this.gameObject.transform.position;
        xPan = new Vector3(speed, 0, 0);
        yPan = new Vector3(0, speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = currentPos;
        //Debug.Log(this.transform.position);

        if (Input.GetKey(KeyCode.W))
        {
            currentPos = Vector3.MoveTowards(currentPos, currentPos += yPan, (speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.A))
        {
            currentPos = Vector3.MoveTowards(currentPos, currentPos -= xPan, (speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S))
        {
            currentPos = Vector3.MoveTowards(currentPos, currentPos -= yPan, (speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.D))
        {
            currentPos = Vector3.MoveTowards(currentPos, currentPos += xPan, (speed * Time.deltaTime));
        }
    }
}
