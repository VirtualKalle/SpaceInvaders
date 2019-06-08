using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private TextMeshProUGUI hudScoreText;

    private int score;

    private void OnEnable()
    {
        EnemyHealth.deathEvent += AddScore;
        EnemyShot.shotHitEvent += AddScore;
    }

    private void OnDisable()
    {
        EnemyHealth.deathEvent -= AddScore;
        EnemyShot.shotHitEvent -= AddScore;
    }

    private void Start()
    {
        score = 0;
        UpdateScore();
    }

    private void AddScore()
    {
        if (GameManager.gameState == GameState.Playing)
        {
            score += 100;
            UpdateScore();
        }
    }

    private void UpdateScore()
    {
        finalScoreText.text = "Score: " + score;
        hudScoreText.text = "Score: " + score;
    }

}
