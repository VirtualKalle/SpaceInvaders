using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private EnemyBlaster blaster;
    private float attackTimeLeft;
    [SerializeField] float maxAttackTime = 10;
    [SerializeField] float minAttackTime = 3;

    private void Awake()
    {
        blaster = GetComponentInChildren<EnemyBlaster>();
    }

    void Start()
    {
        attackTimeLeft = Random.Range(minAttackTime, maxAttackTime);
    }

    void Update()
    {
        if (!GameManager.paused)
        {
            AttackCountDown();
        }
    }

    private void OnTriggerEnter(Collider collision)
    {

        Debug.Log("enemy collision enter");
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.takeDamage(100);
        }
    }

    void AttackCountDown()
    {
        attackTimeLeft -= Time.deltaTime;

        if (attackTimeLeft <= 0)
        {
            TryBlast();
            attackTimeLeft = Random.Range(minAttackTime, maxAttackTime);
        }
    }

    void TryBlast()
    {

        Debug.Log("tryblast");
        RaycastHit hit;
        if (Physics.Raycast(blaster.transform.position, Vector3.down, out hit))
        {
            Debug.Log("ray blast");
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
