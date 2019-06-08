using UnityEngine;

public class EnemyBlaster : MonoBehaviour
{
    private float damage;
    
    public void Blast()
    {
        var shot = EnemyShotPool.Instance.Get();
        shot.transform.rotation = transform.rotation;
        shot.transform.position = transform.position;
        shot.gameObject.SetActive(true);
    }
    
}
