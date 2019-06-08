using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    int health;
    [SerializeField] int startHealth;

    public static int nrOfEnemies { get; private set; }

    public delegate void enemyHealthDelegate();
    public static event enemyHealthDelegate deathEvent;

    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        nrOfEnemies = FindObjectsOfType<EnemyHealth>().Length;
    }

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
        nrOfEnemies--;
        animator.SetBool("dead", true);
        deathEvent();
        SpawnExplosion();
        gameObject.SetActive(false);
    }
    
    void SpawnExplosion()
    {
        var explosion = ExplosionPool.Instance.Get();
        explosion.transform.rotation = transform.rotation;
        explosion.transform.position = transform.position;
        explosion.gameObject.SetActive(true);
    }

}
