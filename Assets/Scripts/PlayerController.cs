using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction aimAction, startPumpAction, endPumpAction;
    public Balloon balloon;
    public Transform pivot;

    private bool inflating = false;
    public float pivotRate = 500f;

    void Awake()
    {
        startPumpAction.performed += ctx => { StartPump(); };
        endPumpAction.performed += ctx => { EndPunp(); };
    }

    void StartPump()
    {
        if (balloon)
        {
            inflating = true;
        }
    }

    void EndPunp()
    {
        if (balloon)
        {
            inflating = false;
            balloon.Launch();
        }
    }

    void Update()
    {
        Aim();
    }

    void Aim()
    {
        float aimAmount = aimAction.ReadValue<float>();

        pivot.eulerAngles = new Vector3(0f, 0f, Mathf.Clamp(pivot.eulerAngles.z + aimAmount * pivotRate * Time.deltaTime, 0f, 90f));
    }

    void FixedUpdate()
    {
        if(inflating)
        {
            balloon.Inflate();
        }
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