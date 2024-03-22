using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    private int health;

    void Start()
    {
        health = Random.Range(2, 7);
    }

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    public void GetDamage()
    {
        health--;
        if (health <= 0)
            Destroy(gameObject);
    }
}
