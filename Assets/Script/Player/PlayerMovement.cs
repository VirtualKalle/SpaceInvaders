using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 2;
    [SerializeField] KeyCode moveRight = KeyCode.D;
    [SerializeField] KeyCode moveLeft = KeyCode.A;
    private float moveLimit = 10;


    private void Start()
    {
        moveLimit = GameManager.gameFieldSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.paused)
        {
            Move();
        }
    }

    void Move()
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
