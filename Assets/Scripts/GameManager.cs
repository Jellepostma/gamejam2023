using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance is null)
            {
                Debug.Log("GameManager is not defined");
            }

            return _instance;
        }
    }

    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI pressAnyKeyToPlayAgainText;

    public PlayerController[] players;

    public InputAction playAgainAction;

    private bool gameOver;

    private void Awake()
    {
        _instance = this;
        
        playAgainAction.performed += ctx =>
        {
            if (gameOver)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        };
    }

    public void GameOver(int loserPlayerId)
    {
        foreach (var player in players)
        {
            player.GameOver();
        }

        foreach (var balloon in GameObject.FindObjectsOfType<Weapon>())
        {
            balloon.Pop();
        }

        ScoreManager.instance.HideScores();
        var winningPlayer = loserPlayerId == 0 ? "One" : "Two";
        var gameOverMessage = "Game Over!\nPlayer " + winningPlayer + " has won";

        gameOverText.text = gameOverMessage;
        pressAnyKeyToPlayAgainText.enabled = true;

        gameOver = true;
    }

    public void OnEnable()
    {
        playAgainAction.Enable();
    }

    public void OnDisable()
    {
        playAgainAction.Disable();
    }
}
