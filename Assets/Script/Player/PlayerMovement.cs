using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    [SerializeField] private KeyCode moveRight = KeyCode.D;
    [SerializeField] private KeyCode moveLeft = KeyCode.A;

    private float moveLimit = 10;


    private void Start()
    {
        moveLimit = GameManager.gameFieldSize;
    }

    private void Update()
    {
        if (GameManager.gameState == GameState.Playing)
        {
            Move();
        }
    }

    private void Move()
    {
        if (Input.GetKey(moveRight) && transform.position.x < moveLimit)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if (Input.GetKey(moveLeft) && transform.position.x > -moveLimit)
        {
            transform.Translate(-Vector3.right * Time.deltaTime * speed);
        }
    }
}
