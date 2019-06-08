using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject HUD;

    [SerializeField] float _gameFieldSize = 10;
    public static float gameFieldSize { get; private set; }

    public static bool paused { get; private set; }


    private void OnEnable()
    {
        EnemyHealth.deathEvent += CheckLevelClear;
        PlayerHealth.deathEvent += MissionFailed;
    }

    private void OnDisable()
    {
        EnemyHealth.deathEvent -= CheckLevelClear;
        PlayerHealth.deathEvent -= MissionFailed;
    }

    private void Awake()
    {
        gameFieldSize = _gameFieldSize;
    }

    void CheckLevelClear()
    {
        Debug.Log("enemies left " + EnemyHealth.nrOfEnemies);
        if (EnemyHealth.nrOfEnemies <= 0)
        {
            LevelComplete();
        }
    }

    void MissionFailed()
    {
        menu.SetActive(true);
        menu.GetComponentInChildren<TextMeshProUGUI>().text = "Mission failed!";
        Pause();
    }

    private void LevelComplete()
    {
        menu.SetActive(true);
        menu.GetComponentInChildren<TextMeshProUGUI>().text = "Level complete!";
        Pause();
    }

    public void RestartGame()
    {
        UnPause();
        SceneManager.LoadScene(0);
    }

    void Pause()
    {
        paused = true;
    }

    void UnPause()
    {
        paused = false;
    }
}
