using UnityEngine;

public enum BonusType
{
    Health,
    SpeedBoost,
    Invincibility
}

public class Bonus : MonoBehaviour
{
    [Header("Bonus Settings")]
    public BonusType bonusType;
    public float duration = 5f;
    public int healthRestore = 20;
    public float speedMultiplier = 1.5f;
    public float lifetime = 10f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.GetComponent<PlayerController>();
        if (player == null) return;

        PlayerHealth health = player.GetComponent<PlayerHealth>();
        if (health == null) return;

        switch (bonusType)
        {
            case BonusType.Health:
                health.RestoreHealth(healthRestore);
                break;

            case BonusType.SpeedBoost:
                player.StartCoroutine(player.TemporarySpeedBoost(speedMultiplier, duration));
                break;

            case BonusType.Invincibility:
                health.StartCoroutine(health.TemporaryInvincibility(duration));
                break;
        }

        Destroy(gameObject);
    }
}
