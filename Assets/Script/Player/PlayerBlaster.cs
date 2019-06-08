using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlaster : MonoBehaviour
{
    float damage;
    
    public void Blast()
    {
        var shot = PlayerShotPool.Instance.Get();
        shot.transform.rotation = transform.rotation;
        shot.transform.position = transform.position;
        shot.gameObject.SetActive(true);
    }
    
}
