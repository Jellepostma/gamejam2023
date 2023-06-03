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

    private int _playerId;

    private float _pivotRate;

    void Awake()
    {
        _pivotRate = GameSettings.Instance.weaponPivotRate;
    }

    public void Initialize(int player)
    {
        _playerId = player;
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
        currentWeapon = GameObject.Instantiate<Weapon>(inventory[_currentWeaponIndex].weapon, transform);
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
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, Mathf.Clamp(transform.eulerAngles.z + aimAmount * _pivotRate * Time.deltaTime, 0f, 90f));
    }
}
