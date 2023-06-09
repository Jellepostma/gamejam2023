using System;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public Weapon currentWeapon;

    public Transform pivot, spawnPoint;

    private int _playerId = 0;

    private float _pivotRate;

    private Weapon currentInventory;

    void Start()
    {
        _pivotRate = GameSettings.Instance.weaponPivotRate;
    }

    public void Initialize(int playerId)
    {
        _playerId = playerId;

        SetWeapon(GameSettings.Instance.startWeapon);
        LoadWeapon();
    }

    public void SetWeapon(Weapon weapon)
    {
        currentInventory = weapon;
    }

    void RemoveWeapon()
    {
        currentInventory = null;
    }

    void LoadWeapon()
    {
        currentWeapon = GameObject.Instantiate<Weapon>(currentInventory, spawnPoint);
        currentWeapon.Initialize(_playerId);
    }

    public void OnStartPump()
    {
        currentWeapon.StartInflating();
        
    }

    public void OnEndPump()
    {
        currentWeapon.Launch();

        if(currentInventory == null)
        {
            SetWeapon(GameSettings.Instance.startWeapon);
        }

        LoadWeapon();
        currentInventory = null;
    }

    public void Aim(float aimAmount)
    {
        pivot.transform.eulerAngles = new Vector3(Mathf.Clamp(pivot.transform.eulerAngles.x + aimAmount * _pivotRate * Time.deltaTime, 0f, 90f), pivot.transform.eulerAngles.y, pivot.transform.eulerAngles.z);
    }
}
