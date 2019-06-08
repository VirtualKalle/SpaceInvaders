using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShot : MonoBehaviour
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
            PlayerShotPool.Instance.ReturnToPool(this);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("player shot col enter " + col.gameObject.name);
        EnemyHealth enemyHealth = col.gameObject.GetComponent<EnemyHealth>();

        if (enemyHealth != null)
        {
            enemyHealth.takeDamage(damage);
            PlayerShotPool.Instance.ReturnToPool(this);
        }

        EnemyShot enemyShot = col.gameObject.GetComponent<EnemyShot>();

        if (enemyShot != null)
        {
            PlayerShotPool.Instance.ReturnToPool(this);
        }

    }

}
