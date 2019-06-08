using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    int score;
    [SerializeField] TextMeshProUGUI finalScoreText;
    [SerializeField] TextMeshProUGUI hudScoreText;


    private void OnEnable()
    {
        EnemyHealth.deathEvent += AddScore;
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateScore();
    }
    
    private void AddScore()
    {
        score += 100;
        UpdateScore();
    }

    void UpdateScore()
    {
        finalScoreText.text = "Score: " + score;
        hudScoreText.text = "Score: " + score;
    }

}
