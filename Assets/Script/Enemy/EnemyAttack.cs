using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float maxAttackTime = 10;
    [SerializeField] private float minAttackTime = 3;

    private EnemyBlaster blaster;
    private float attackTimeLeft;


    private void Awake()
    {
        blaster = GetComponentInChildren<EnemyBlaster>();
    }

    private void Start()
    {
        attackTimeLeft = Random.Range(minAttackTime, maxAttackTime);
    }

    private void Update()
    {
        if (GameManager.gameState == GameState.Playing)
        {
            AttackCountDown();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.takeDamage(100);
        }
    }

    private void AttackCountDown()
    {
        attackTimeLeft -= Time.deltaTime;

        if (attackTimeLeft <= 0)
        {
            TryBlast();
            attackTimeLeft = Random.Range(minAttackTime, maxAttackTime);
        }
    }

    private void TryBlast()
    {
        RaycastHit hit;

        if (Physics.Raycast(blaster.transform.position, Vector3.down, out hit))
        {
            if (!hit.collider.gameObject.GetComponent<EnemyHealth>())
            {
                Debug.Log("success tryblast");
                blaster.Blast();
            }
        }
        else
        {
            blaster.Blast();
        }
        
    }
}
