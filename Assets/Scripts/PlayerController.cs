using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction aimAction, startPumpAction, endPumpAction;
    public WeaponManager weaponManager;

    

    void Awake()
    {
        startPumpAction.performed += ctx => { weaponManager.OnStartPump(); };
        endPumpAction.performed += ctx => { weaponManager.OnEndPump(); };

        weaponManager.LoadWeapon();
    }

    void Update()
    {
        float aimAmount = aimAction.ReadValue<float>();
        weaponManager.Aim(aimAmount);
    }

    public void OnEnable()
    {
        startPumpAction.Enable();
        endPumpAction.Enable();
        aimAction.Enable();
    }

    public void OnDisable()
    {
        startPumpAction.Disable();
        endPumpAction.Disable();
        aimAction.Disable();
    }

}