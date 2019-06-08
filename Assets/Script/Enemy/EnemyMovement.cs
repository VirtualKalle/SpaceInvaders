using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float horizontalStepDistance = 0.5f;
    [SerializeField] private float verticalStepDistance = 0.5f;

    private bool moveRight = true;
    private float moveTimeLeft;
    private float moveTimeInterval = 1;
    private float moveLimit;

    private Transform[] enemies;


    private void Start()
    {
        moveTimeLeft = moveTimeInterval;
        moveLimit = LevelManager.gameFieldSize;
    }

    private void Update()
    {
        if (GameManager.gameState == GameState.Playing)
        {
            MoveCountDown();
        }
    }

    private void MoveCountDown()
    {
        moveTimeLeft -= Time.deltaTime;

        if (moveTimeLeft < 0)
        {
            Move();
            moveTimeLeft = moveTimeInterval;
        }

    }

    private void Move()
    {
        enemies = GetEnemyTransforms();
        GetEnemiesEdgePositions(out float rightEdgePosition, out float leftEdgePosition);

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
            MoveVertical();
        }
    }

    private void MoveVertical()
    {
        transform.Translate(Vector3.down * verticalStepDistance);
        moveRight = !moveRight;
        moveTimeInterval *= 0.8f;

        float animationSpeed;
        animationSpeed = enemies[0].GetComponent<Animator>().GetFloat("speed");

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].GetComponent<Animator>().SetFloat("speed", animationSpeed * 1.1f);
        }
    }

    private void GetEnemiesEdgePositions(out float rightEdgePosition, out float leftEdgePosition)
    {
        rightEdgePosition = enemies[0].position.x;
        leftEdgePosition = enemies[0].position.x;

        for (int i = 0; i < enemies.Length; i++)
        {
            rightEdgePosition = Mathf.Max(enemies[i].position.x, rightEdgePosition);
            leftEdgePosition = Mathf.Min(enemies[i].position.x, leftEdgePosition);
        }
    }

    private Transform[] GetEnemyTransforms()
    {
        EnemyHealth[] enemyHealths = GetComponentsInChildren<EnemyHealth>();
        List<Transform> enemiesList = new List<Transform>();

        for (int i = 0; i < enemyHealths.Length; i++)
        {
            enemiesList.Add(enemyHealths[i].transform);
        }

        return enemiesList.ToArray();
    }
}
