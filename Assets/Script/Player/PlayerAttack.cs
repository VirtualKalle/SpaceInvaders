using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private KeyCode attackButton = KeyCode.Space;

    private PlayerBlaster blaster;

    private void Awake()
    {
        blaster = GetComponentInChildren<PlayerBlaster>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(attackButton) && GameManager.gameState == GameState.Playing)
        {
            blaster.Blast();
        }
    }
}
