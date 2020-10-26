using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lysol : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody.velocity = transform.rotation * Vector3.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
