using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigidBody;
    public float lifetime = 5f;
    SporeHealth sporeHealth;
    SpawnerHealth spawnerHealth;

    void Start()
    {
        this.tag = "PlayerBullet"; //projectiles can move through each other.
        rigidBody.velocity = transform.rotation * Vector3.right * speed;
        Destroy(gameObject, lifetime);

    }

    
    private void OnTriggerEnter2D(Collider2D collider) //On"Collision"Enter2D collider if wanting to activate on collider instead of a trigger.
    {
        if (!collider.gameObject.CompareTag("Player") && !collider.gameObject.CompareTag("PlayerBullet")) //move through players.
        {
            if (collider.gameObject.CompareTag("SporeGreen") || collider.gameObject.CompareTag("SporeRed") || collider.gameObject.CompareTag("SporeBlack"))
            {
                sporeHealth = collider.gameObject.GetComponent<SporeHealth>();
                sporeHealth.TakeDamage(5);
            } else if (collider.gameObject.CompareTag("SporeGreenSpawner") || collider.gameObject.CompareTag("SporeRedSpawner") || collider.gameObject.CompareTag("SporeBlackSpawner"))
            {
                spawnerHealth = collider.gameObject.GetComponent<SpawnerHealth>();
                spawnerHealth.TakeDamage(5);
            }
            Destroy(this.gameObject);
            return;
        } //Debug.Log("Projectile ignored something.");
    }
}
