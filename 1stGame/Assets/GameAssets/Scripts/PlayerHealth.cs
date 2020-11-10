﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("SporeGreen") || collision.gameObject.tag == "SporeBlack" || collision.gameObject.tag == "SporeRed")
        {
            TakeDamage(5);
        } else if (collision.gameObject.CompareTag("SporeGreenSpawner") || collision.gameObject.tag == "SporeBlackSpawner" || collision.gameObject.tag == "SporeRedSpawner")
        {
            TakeDamage(15);
        }

    }


    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
