using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] KeyCode attackButton = KeyCode.Space;

    PlayerBlaster blaster;

    private void Awake()
    {
        blaster = GetComponentInChildren<PlayerBlaster>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(attackButton) && !GameManager.paused)
        {
            blaster.Blast();
        }
    }
}
