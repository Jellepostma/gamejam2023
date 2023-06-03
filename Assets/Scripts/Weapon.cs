using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float inflation = 0f; // 0 to 1
    public float inflationSpeed = 0.05f;
    public float force = 20f;

    private Rigidbody rb;
    private Collider col;
    private bool launched = false;

    public int OwnerId;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    public void Initialize(int playerId)
    {
        this.OwnerId = playerId;
    }

    public void StartInflating()
    {
        StartCoroutine(Inflate());
    }

    IEnumerator Inflate()
    {
        while(!launched && inflation < 1f)
        {
            inflation = Mathf.Clamp01(inflation + inflationSpeed * Time.deltaTime);
            transform.localScale = Vector3.one * inflation;
            yield return null;
        }
    }

    public void Launch()
    {
        launched = true;
        transform.parent = null;
        col.enabled = true;
        rb.useGravity = true;
        rb.AddForce(gameObject.transform.forward * force * inflation);
    }

    public void Pop()
    {
        Destroy(gameObject);
    }
}
