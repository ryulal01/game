using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private GameObject[] bonusPrefabs; // Префабы бонусов
    [SerializeField] private Transform player;           // Игрок
    [SerializeField] private float spawnInterval = 8f;   // Интервал появления бонусов
    [SerializeField] private float spawnDistance = 25f;  // Расстояние перед игроком

    [Header("Lanes (X positions)")]
    [SerializeField] private float[] lanes = { -2f, 0f, 2f };

    private float timer;

    private void Update()
    {
        if (player == null || bonusPrefabs.Length == 0)
            return;

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnBonus();
            timer = 0f;
        }
    }

    private void SpawnBonus()
    {
        int prefabIndex = Random.Range(0, bonusPrefabs.Length);
        int laneIndex = Random.Range(0, lanes.Length);

        Vector3 spawnPosition = new Vector3(
            lanes[laneIndex],
            0.5f,
            player.position.z + spawnDistance
        );

        Instantiate(bonusPrefabs[prefabIndex], spawnPosition, Quaternion.identity);
    }
}
