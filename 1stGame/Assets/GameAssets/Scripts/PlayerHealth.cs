using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public bool playerDeathEnabled;
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("SporeGreen") || collision.gameObject.tag == "SporeBlack" || collision.gameObject.tag == "SporeRed")
        {
            TakeDamage(5);
        } else if (collision.gameObject.CompareTag("SporeGreenSpawner") || collision.gameObject.tag == "SporeBlackSpawner" || collision.gameObject.tag == "SporeRedSpawner")
        {
            TakeDamage(15);
        } else if (collision.gameObject.CompareTag("mask") && currentHealth <maxHealth)
        {

            if (currentHealth <= 60)
            {
                TakeDamage(-40);
            } else if (currentHealth > 60)
            {
                TakeDamage(-(100 - currentHealth));
            }
            GameObject.Destroy(collision.gameObject);
        }
        if ( (currentHealth <= 0) && playerDeathEnabled )
        {
            GameObject.Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            SceneManager.LoadScene(2);
        }
    }


    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
