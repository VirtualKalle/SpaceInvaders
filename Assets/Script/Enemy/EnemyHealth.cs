using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int startHealth;

    public static int nrOfEnemies { get; private set; }
    public delegate void enemyHealthDelegate();
    public static event enemyHealthDelegate deathEvent;

    private Color startColor;
    private int health;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        startColor = GetComponent<SpriteRenderer>().color;
        health = startHealth;
        nrOfEnemies = FindObjectsOfType<EnemyHealth>().Length;
    }

    public void takeDamage(int damage)
    {
        health -= damage;
        Color color = new Color();
        color = new Color(startColor.r * startHealth / startHealth, startColor.g * health / startHealth, startColor.b * health / startHealth);
        GetComponent<SpriteRenderer>().color = color;

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

    private void SpawnExplosion()
    {
        var explosion = ExplosionPool.Instance.Get();
        explosion.transform.rotation = transform.rotation;
        explosion.transform.position = transform.position;
        explosion.gameObject.SetActive(true);
    }

}
