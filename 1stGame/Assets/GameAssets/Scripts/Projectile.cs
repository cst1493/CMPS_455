using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigidBody;
    public float lifetime = 5f;
    void Start()
    {
        rigidBody.velocity = transform.right * speed;
        Destroy(gameObject, lifetime);

    }
}
