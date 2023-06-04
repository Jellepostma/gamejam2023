using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public Weapon weapon;

    public Vector2 speedRange;

    private float speed;

    private void Awake()
    {
        speed = Random.Range(speedRange.x, speedRange.y);
    }

    private void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime);
    }
}
