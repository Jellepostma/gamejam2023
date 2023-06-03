using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    private static GameSettings _instance;
    public static GameSettings instance
    {
        get
        {
            if (_instance is null)
            {
                Debug.Log("GameSettings is not defined");
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    public float weaponPivotRate = 100f;
}
