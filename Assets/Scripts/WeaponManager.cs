using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [System.Serializable]
    public class InventoryItem
    {
        public Weapon weapon;
        public int amount;
    }

    public List<InventoryItem> inventory = new();

    private int _currentWeaponIndex;

    public Weapon currentWeapon;

    public Transform pivot, spawnPoint;

    private int _playerId = 0;

    private float _pivotRate;

    void Start()
    {
        _pivotRate = GameSettings.Instance.weaponPivotRate;
    }

    public void Initialize(int playerId)
    {
        _playerId = playerId;
        LoadWeapon();
    }

    public void NextWeapon()
    {
        while (inventory[_currentWeaponIndex].amount == 0)
        {
            _currentWeaponIndex = Mathf.RoundToInt(Mathf.Repeat(++_currentWeaponIndex, inventory.Count));
        }
    }

    public void PreviousWeapon()
    {
        while (inventory[_currentWeaponIndex].amount == 0)
        {
            _currentWeaponIndex = Mathf.RoundToInt(Mathf.Repeat(--_currentWeaponIndex, inventory.Count));
        }
    }

    public void LoadWeapon()
    {
        currentWeapon = GameObject.Instantiate<Weapon>(inventory[_currentWeaponIndex].weapon, spawnPoint);
        currentWeapon.Initialize(_playerId);
    }

    public void OnStartPump()
    {
        currentWeapon.StartInflating();
        inventory[_currentWeaponIndex].amount--;
    }

    public void OnEndPump()
    {
        currentWeapon.Launch();
        LoadWeapon();
    }

    public void Aim(float aimAmount)
    {
        pivot.transform.eulerAngles = new Vector3(Mathf.Clamp(pivot.transform.eulerAngles.x + aimAmount * _pivotRate * Time.deltaTime, 0f, 90f), pivot.transform.eulerAngles.y, pivot.transform.eulerAngles.z);
    }
}
