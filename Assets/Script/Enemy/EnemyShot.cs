using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
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
            EnemyShotPool.Instance.ReturnToPool(this);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("enemy shot collision enter");
        PlayerHealth playerHealth = col.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.takeDamage(damage);
            EnemyShotPool.Instance.ReturnToPool(this);
        }

        PlayerShot playerShot = col.gameObject.GetComponent<PlayerShot>();
        if (playerShot != null)
        {
            SpawnExplosion();
            EnemyShotPool.Instance.ReturnToPool(this);
        }

    }

    void SpawnExplosion()
    {
        var explosion = ExplosionPool.Instance.Get();
        explosion.transform.rotation = transform.rotation;
        explosion.transform.position = transform.position;
        explosion.gameObject.SetActive(true);
    }

}
