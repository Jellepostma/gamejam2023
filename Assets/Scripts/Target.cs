using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "balloon")
        {
            Destroy(gameObject);
        }
    }
}
