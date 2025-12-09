using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Obstacle : MonoBehaviour
{
    [Header("Obstacle Settings")]
    [SerializeField] private int damage = 10;
    [SerializeField] private float lifetime = 10f;

    private void Start()
    {
        // Автоудаление препятствия через время
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Проверяем, игрок ли это
        PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
        }
    }

    // Можно добавить геттер для урона, если вдруг понадобится
    public int GetDamage()
    {
        return damage;
    }
}

