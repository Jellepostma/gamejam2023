using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("balloon"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
