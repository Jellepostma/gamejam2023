using System;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

public class FishManager : MonoBehaviour
{
    public GameObject prefab;

    public float fishForceMax = 1000f;
    public float fishForceMin = 600f;

    public float spawnFishOn;

    private float yMax = 32f;
    private float yMin = 3f;
    private int xMax = 33;
    private int xMin = -33;
    private int z = 11;

    private void Update()
    {
        if (spawnFishOn == 0f || spawnFishOn - Time.time <= 0)
        {
            SpawnFish();
            spawnFishOn = Time.time + Random.Range(2, 3);
        }
    }

    private void SpawnFish()
    {
        var fish = Instantiate(prefab);

        var direction = Random.Range(0, 2) == 1;
        var x = direction ? xMin : xMax;
        var y = Random.Range(yMin, yMax);
        var force = Random.Range(fishForceMin, fishForceMax);

        fish.transform.Rotate(new Vector3(0, (direction ? 0 : 180), 0));
        fish.transform.position = new Vector3(x, y, z);
        fish.GetComponent<Rigidbody>().AddForce(new Vector3(direction ? force : -force, 0, 0), ForceMode.Impulse);
    }
}
