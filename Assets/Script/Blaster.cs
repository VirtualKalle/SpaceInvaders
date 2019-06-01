using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : MonoBehaviour
{
    float damage;
    [SerializeField] KeyCode attackButton = KeyCode.Space;
    
    void Blast()
    {
        var shot = ShotPool.Instance.Get();
        shot.transform.rotation = transform.rotation;
        shot.transform.position = transform.position;
        shot.gameObject.SetActive(true);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(attackButton))
        {
            Blast();
        }
    }
}
