using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Bullet projectilePrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private float actionInterval = 0.2f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= actionInterval)
        {
            Shoot();

            timer = 0f;
        }
    }

    void Shoot()
    {
        var projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
        projectile.Move(Vector3.up);

        for (int i = -1; i <= 1; i += 2)
        {
            var angledProjectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
            Vector3 angledDirection = Quaternion.AngleAxis(45f * i, Vector3.forward) * Vector3.up;
            angledProjectile.Move(angledDirection);
        }
    }
}
