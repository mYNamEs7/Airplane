using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float actionInterval = 2f;
    [SerializeField] private Enemy enemyPrefab;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= actionInterval)
        {
            int rand = Random.Range(1, 3);
            for (int i = 0; i < rand; i++)
            {
                SpawnObject();
            }

            timer = 0f;
            actionInterval = Random.Range(2f, 7f);
        }
    }

    void SpawnObject()
    {
        var mainCamera = Camera.main;
        float cameraHeight = mainCamera.orthographicSize;

        Vector3 cameraTopPosition = mainCamera.transform.position + Vector3.up * cameraHeight;

        Vector3 spawnPosition = new Vector3(Random.Range(mainCamera.transform.position.x - mainCamera.aspect * cameraHeight, mainCamera.transform.position.x + mainCamera.aspect * cameraHeight), cameraTopPosition.y + 1f, 0f);

        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
