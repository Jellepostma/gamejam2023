using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [System.Serializable]
    public class InventoryItem
    {
        public Balloon balloon;
        public int amount = 0;
    }

    public List<InventoryItem> Inventory = new List<InventoryItem>();

    private int currentWeaponIndex = 0;

    public Balloon currentWeapon;

    public float pivotRate = 500f;

    public void NextWeapon()
    {
        while (Inventory[currentWeaponIndex].amount == 0)
        {
            currentWeaponIndex = Mathf.RoundToInt(Mathf.Repeat(++currentWeaponIndex, Inventory.Count));
        }
    }

    public void PreviousWeapon()
    {
        while (Inventory[currentWeaponIndex].amount == 0)
        {
            currentWeaponIndex = Mathf.RoundToInt(Mathf.Repeat(--currentWeaponIndex, Inventory.Count));
        }
    }

    public void LoadWeapon()
    {
        currentWeapon = GameObject.Instantiate<Balloon>(Inventory[currentWeaponIndex].balloon, transform);
    }

    public void OnStartPump()
    {
        currentWeapon.StartInflating();
        Inventory[currentWeaponIndex].amount--;
    }

    public void OnEndPump()
    {
        currentWeapon.Launch();
        LoadWeapon();
    }

    public void Aim(float aimAmount)
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, Mathf.Clamp(transform.eulerAngles.z + aimAmount * pivotRate * Time.deltaTime, 0f, 90f));
    }
}
