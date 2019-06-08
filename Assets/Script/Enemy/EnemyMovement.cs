using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private bool moveRight = true;

    private float moveTimeLeft;
    private float moveTimeInterval = 1;
    private float moveLimit;

    [SerializeField] float horizontalStepDistance = 0.5f;
    [SerializeField] float verticalStepDistance = 0.5f;

    void Start()
    {
        moveTimeLeft = moveTimeInterval;
        moveLimit = GameManager.gameFieldSize;
    }

    void Update()
    {
        if (!GameManager.paused)
        {
            MoveCountDown();
        }
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
        EnemyHealth[] enemyHealths = GetComponentsInChildren<EnemyHealth>();
        float rightEdgePosition = enemyHealths[0].transform.position.x;
        float leftEdgePosition = enemyHealths[0].transform.position.x;

        for (int i = 0; i < enemyHealths.Length; i++)
        {
            rightEdgePosition = Mathf.Max(enemyHealths[i].transform.position.x, rightEdgePosition);
            leftEdgePosition = Mathf.Min(enemyHealths[i].transform.position.x, leftEdgePosition);
        }

        if (moveRight && rightEdgePosition < moveLimit)
        {
            transform.Translate(Vector3.right * horizontalStepDistance);
        }
        else if (!moveRight && leftEdgePosition > -moveLimit)
        {
            transform.Translate(Vector3.left * horizontalStepDistance);
        }
        else
        {
            transform.Translate(Vector3.down * verticalStepDistance);
            moveRight = !moveRight;
            moveTimeInterval *= 0.8f;

            float animationSpeed;
            for (int i = 0; i < enemyHealths.Length; i++)
            {
                animationSpeed = enemyHealths[i].GetComponent<Animator>().GetFloat("speed");
                enemyHealths[i].GetComponent<Animator>().SetFloat("speed", animationSpeed * 1.1f);
            }

        }
    }
}
