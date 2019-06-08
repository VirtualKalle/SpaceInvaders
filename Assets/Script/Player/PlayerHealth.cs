using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int startHealth;
    [SerializeField] private GameObject explosionPrefab;

    public delegate void playerHealthDelegate();
    public static event playerHealthDelegate deathEvent;

    private int health = 1;

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
