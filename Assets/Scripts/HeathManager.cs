using UnityEngine;
using TMPro;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance;

    [SerializeField] private TMP_Text healthText;
    [SerializeField] private int maxHealth = 100;

    private int currentHealth;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        currentHealth = maxHealth;
    }

    private void UpdateUI()
    {
        healthText.text = $"HP: {currentHealth}";
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;
        UpdateUI();
    }

    public void Heal(int value)
    {
        currentHealth += value;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        UpdateUI();
    }
}
