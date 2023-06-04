using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float inflation = 0f; // 0 to 1
    public float inflationSpeed = 0.05f;
    public float force = 20f;
    public SkinnedMeshRenderer skinnedMeshRenderer;
    public int damage;
    public GameObject bubble;

    private Rigidbody rb;
    private Collider col;
    private bool launched = false;

    public int OwnerId;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("fish"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    public void Initialize(int playerId)
    {
        this.OwnerId = playerId;
        skinnedMeshRenderer.SetBlendShapeWeight(0, 100f); // Deflate
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
            skinnedMeshRenderer.SetBlendShapeWeight(0, 100f - (inflation * 100f));
            yield return null;
        }
    }

    public void Launch()
    {
        launched = true;
        transform.parent = null;
        col.enabled = true;
        rb.useGravity = true;
        rb.AddForce(-gameObject.transform.right * force * inflation);
    }

    public void Pop()
    {
        Destroy(gameObject);
    }
}
