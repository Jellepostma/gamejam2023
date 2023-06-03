using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public PlayerController[] players;

    private void Awake()
    {
        _instance = this;
    }

    public void GameOver()
    {
        foreach (var player in players)
        {
            player.GameOver();
        }

        foreach (var balloon in GameObject.FindObjectsOfType<Weapon>())
        {
            balloon.Pop();
        }
    }
}
