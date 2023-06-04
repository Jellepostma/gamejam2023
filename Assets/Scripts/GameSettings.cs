using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItem
{
    public Weapon prefab;
    public GameObject bubblePrefab;
}

public class GameSettings : MonoBehaviour
{
    private static GameSettings _instance;
    public static GameSettings Instance
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

    public InventoryItem startWeapon;
    public InventoryItem[] weaponList;
}
