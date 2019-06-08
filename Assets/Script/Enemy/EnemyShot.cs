using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private int damage = 100;
    [SerializeField] private float lifeTime = 3f;

    private float lifeTimeLeft;

    public delegate void shotDelegate();
    public static event shotDelegate shotHitEvent;

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
            EnemyShotPool.Instance.ReturnToPool(this);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
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
            shotHitEvent();
            EnemyShotPool.Instance.ReturnToPool(this);
        }

    }

    private void SpawnExplosion()
    {
        var explosion = ExplosionPool.Instance.Get();
        explosion.transform.rotation = transform.rotation;
        explosion.transform.position = transform.position;
        explosion.gameObject.SetActive(true);
    }

}
