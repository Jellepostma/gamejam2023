using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    private static ScoreManager _instance;
    public static ScoreManager instance
    {
        get
        {
            if (_instance is null)
            {
               Debug.Log("Score manager is not defined");
            }

            return _instance;
        }
    }

    public int[] scores = { 0, 0 };
    public TextMeshProUGUI[] scoreTexts = { };

    private void Awake()
    {
        _instance = this;
    }

    public void AddScore(int player, int score)
    {
        scores[player] += score;
        scoreTexts[player].text = "Score: " + scores[player];
    }

}
