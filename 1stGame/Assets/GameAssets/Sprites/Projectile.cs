using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigidBody;
    void Start()
    {
        rigidBody.velocity = transform.right * speed;
    }
}
