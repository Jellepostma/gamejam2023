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


    private void Update()
    {
        if ((spawnBubbleOn == 0f || spawnBubbleOn - Time.time <= 0))
        {
            SpawnBubble();
            spawnBubbleOn = Time.time + Random.Range(2, 8);
        }
    }

    private void SpawnBubble()
    {
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

}
