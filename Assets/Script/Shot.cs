using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] int damage = 100;

    [SerializeField] float lifeTime = 3f;
    private float lifeTimeLeft;

    private void OnEnable()
    {
        lifeTimeLeft = lifeTime;
    }

    void Update()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        lifeTimeLeft -= Time.deltaTime;
        if (lifeTimeLeft < 0)
        {
            ShotPool.Instance.ReturnToPool(this);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision enter");
        EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.takeDamage(damage);
        }

        ShotPool.Instance.ReturnToPool(this);
    }

    private void Hit()
    {

    }
}
