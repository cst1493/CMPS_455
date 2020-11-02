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
        this.tag = "Player"; //projectiles can move through each other.
        rigidBody.velocity = transform.rotation * Vector3.right * speed;
        Destroy(gameObject, lifetime);

    }

    
    private void OnTriggerEnter2D(Collider2D collider) //On"Collision"Enter2D collider if wanting to activate on collider instead of a trigger.
    {
        if ( collider.gameObject.tag != "Player" ) //move through players.
        {
            if (collider.gameObject.tag == "Enemy")
            {
                Debug.Log("Project hit an enemy");
                //TODO deal damage to enemy.
            }
            Destroy(this.gameObject);
            return;
        } //Debug.Log("Projectile ignored something.");
    }
}
