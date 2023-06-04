using System;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

public class FishManager : MonoBehaviour
{
    public GameObject prefab;

    public int maxFishAmount = 20;
    private int fishAmount;
    
    public float fishForceMax = 1000f;
    public float fishForceMin = 600f;

    public float spawnFishOn;

    private float yMax = 32f;
    private float yMin = 3f;
    private int xMax = 33;
    private int xMin = -33;
    private int z = 11;
    
    private static FishManager _instance;
    public static FishManager Instance
    {
        get
        {
            if (_instance is null)
            {
                Debug.Log("FishManager is not defined");
            }

            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        if ((spawnFishOn == 0f || spawnFishOn - Time.time <= 0) && fishAmount < maxFishAmount)
        {
            SpawnFish();
            spawnFishOn = Time.time + Random.Range(1, 2);
        }
    }

    private void SpawnFish()
    {
        fishAmount++;
        var fish = Instantiate(prefab);

        var direction = Random.Range(0, 2) == 1;
        var x = direction ? xMin : xMax;
        var y = Random.Range(yMin, yMax);
        var force = Random.Range(fishForceMin, fishForceMax);
        
        fish.transform.Rotate(new Vector3(direction ? 90 : -90, 0, 0));
        fish.transform.position = new Vector3(x, y, z);
        fish.GetComponent<Rigidbody>().AddForce(new Vector3(direction ? force : -force, 0, 0), ForceMode.Impulse);
    }

    public void DecreaseFish()
    {
        fishAmount--;
    }
}
