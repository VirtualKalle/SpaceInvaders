using UnityEngine;

public class PlayerShot : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private int damage = 100;
    [SerializeField] private float lifeTime = 3f;

    private float lifeTimeLeft;

    private void OnEnable()
    {
        lifeTimeLeft = lifeTime;
    }

    private void Update()
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
