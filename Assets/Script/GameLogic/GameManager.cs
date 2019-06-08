using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject HUD;

    public static GameState gameState { get; private set; } = GameState.Playing;


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


    private void CheckLevelClear()
    {
        if (EnemyHealth.nrOfEnemies <= 0 && gameState == GameState.Playing)
        {
            LevelComplete();
        }
    }

    private void MissionFailed()
    {
        if (gameState == GameState.Playing)
        {
            menu.SetActive(true);
            menu.GetComponentInChildren<TextMeshProUGUI>().text = "Mission failed!";
            gameState = GameState.Failed;
        }
    }

    private void LevelComplete()
    {
        menu.SetActive(true);
        menu.GetComponentInChildren<TextMeshProUGUI>().text = "Level complete!";
        gameState = GameState.Complete;
    }

    public void RestartGame()
    {
        gameState = GameState.Playing;
        SceneManager.LoadScene(0);
    }

}
