using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private GameObject[] obstaclePrefabs;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float spawnDistance = 20f;

    [Header("Lanes")]
    [SerializeField] private float[] lanes = { -2f, 0f, 2f };

    [SerializeField] private Transform player;

    private float timer;

    private void Update()
    {
        if (player == null || obstaclePrefabs.Length == 0)
            return;

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObstacle();
            timer = 0f;
        }
    }

    private void SpawnObstacle()
    {
        int prefabIndex = Random.Range(0, obstaclePrefabs.Length);
        int laneIndex = Random.Range(0, lanes.Length);

        Vector3 spawnPosition = new Vector3(
            lanes[laneIndex],
            0f,
            player.position.z + spawnDistance
        );

        Instantiate(obstaclePrefabs[prefabIndex], spawnPosition, Quaternion.identity);
    }
}

