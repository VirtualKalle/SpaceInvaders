using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    bool moveRight = true;
    private float moveTimeLeft;
    private float moveTimeInterval = 1;
    private float moveLimit = 5;

    void Start()
    {
        moveTimeLeft = moveTimeInterval;    
    }

    void Update()
    {
        MoveCountDown();
    }

    void MoveCountDown()
    {
        moveTimeLeft -= Time.deltaTime;

        if (moveTimeLeft < 0)
        {
            MoveHorizontal();
            moveTimeLeft = moveTimeInterval;
        }

    }

    void MoveHorizontal()
    {
        if (moveRight && transform.position.x < moveLimit)
        {
            transform.Translate(Vector3.right);
        }
        else if(!moveRight && transform.position.x > -moveLimit)
        {
            transform.Translate(Vector3.left);
        }
        else if (Mathf.Abs(transform.position.x) >= moveLimit)
        {
            transform.Translate(Vector3.down);
            moveRight = !moveRight;
        }
    }

}
