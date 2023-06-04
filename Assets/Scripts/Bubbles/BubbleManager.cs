using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    public GameObject dogPrefab;
    public GameObject sushiPrefab;
    public GameObject ouiPrefab;
    
    private int xMax = -22;
    private int xMin = 22;
    private int y = 0;
    private int z = 11;

    private float spawnBubbleOn = 0f;

    public int maxBubbleAmount;
    public int bubbleAmount;
    
    private static BubbleManager _instance;
    public static BubbleManager Instance
    {
        get
        {
            if (_instance is null)
            {
                Debug.Log("BubbleManager is not defined");
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
        if ((spawnBubbleOn == 0f || spawnBubbleOn - Time.time <= 0) && bubbleAmount < maxBubbleAmount)
        {
            SpawnBubble();
            spawnBubbleOn = Time.time + Random.Range(5, 10);
        }
    }

    private void SpawnBubble()
    {
        bubbleAmount++;
        var choice = Random.Range(0, 3);
        var prefab = dogPrefab;
        if (choice == 1)
        {
            prefab = sushiPrefab;
        } else if (choice == 2)
        {
            prefab = ouiPrefab;
        }
        var bubble = Instantiate(prefab);

        var x = Random.Range(xMax, xMin);
        
        bubble.transform.position = new Vector3(x, y, z);
    }

    public void DecreaseBubbles()
    {
        bubbleAmount--;
    }

}
