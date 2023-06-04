using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("weapon"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
