using UnityEngine;

public class ExplosionManager : MonoBehaviour
{
    private float lifeTime = 0.1f;
    private float lifeTimeLeft;


    private void OnEnable()
    {
        lifeTimeLeft = lifeTime;
    }

    private void Update()
    {
        lifeTimeLeft -= Time.deltaTime;

        if (lifeTimeLeft <= 0)
        {
            ExplosionPool.Instance.ReturnToPool(this);
        }
    }
}
