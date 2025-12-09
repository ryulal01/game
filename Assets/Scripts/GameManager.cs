using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerController player;

    [Header("Difficulty Scaling")]
    [SerializeField] private float speedIncrease = 0.5f;
    [SerializeField] private float increaseInterval = 5f;

    private float timer;

    private void Update()
    {
        if (player == null)
            return;

        timer += Time.deltaTime;

        if (timer >= increaseInterval)
        {
            player.IncreaseSpeed(speedIncrease);
            timer = 0f;
        }
    }
}

