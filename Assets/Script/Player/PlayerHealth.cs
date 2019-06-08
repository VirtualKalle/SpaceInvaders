using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    int health = 1;
    [SerializeField] int startHealth;

    [SerializeField] GameObject explosionPrefab;

    public delegate void playerHealthDelegate();
    public static event playerHealthDelegate deathEvent;

    public void takeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        deathEvent();
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        gameObject.SetActive(false);
    }
    
}
