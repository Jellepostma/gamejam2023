using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    public float inflation = 0f; // 0 to 1
    public float inflationSpeed = 0.05f;
    public float force = 20f;

    private Rigidbody rb;

    public int OwnerId;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    public void Inflate()
    {
        inflation = Mathf.Clamp01(inflation + inflationSpeed * Time.deltaTime);
        transform.localScale = Vector3.one * inflation;
    }

    public void Launch()
    {
        rb.useGravity = true;
        rb.AddForce(gameObject.transform.forward * force * inflation);
    }
}
