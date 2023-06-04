using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

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
        transform.Translate(transform.up * (speed * Time.deltaTime));

        if (transform.position.y > 50)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("weapon") || other.CompareTag("superweapon"))
        {
            var playerId = other.GetComponent<Weapon>().OwnerId;
            GameManager.Instance.players[playerId].weaponManager.SetWeapon(weapon);
            Destroy(gameObject);
            Destroy(other.gameObject);
            
        }
    }
}
