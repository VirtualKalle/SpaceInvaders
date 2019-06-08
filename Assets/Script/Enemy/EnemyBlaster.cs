using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBlaster : MonoBehaviour
{
    float damage;
    
    public void Blast()
    {
        var shot = EnemyShotPool.Instance.Get();
        shot.transform.rotation = transform.rotation;
        shot.transform.position = transform.position;
        shot.gameObject.SetActive(true);
    }
    
}
