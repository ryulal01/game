using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;
    private bool isInvincible = false;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void RestartScene()
    {
        // Перезапуск текущей сцены
        ScoreManager.Instance.ResetScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void TakeDamage(int damage)
    {
        if (damage <= 0 || isInvincible) return;

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log($"Player took {damage} damage. Health = {currentHealth}");

        if (currentHealth <= 0)
        {
			ScoreManager.Instance.SaveHighScore();
            Debug.Log("Restarting...");
            RestartScene();
        }
    }

    // ✅ ВОССТАНОВЛЕНИЕ ЗДОРОВЬЯ
    public void RestoreHealth(int amount)
    {
        if (amount <= 0) return;

        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        Debug.Log($"Healed for {amount}. Health = {currentHealth}");
    }

    // ✅ ВРЕМЕННАЯ НЕУЯЗВИМОСТЬ
    public IEnumerator TemporaryInvincibility(float duration)
    {
        isInvincible = true;
        Debug.Log("Invincibility active!");
        yield return new WaitForSeconds(duration);
        isInvincible = false;
        Debug.Log("Invincibility ended.");
    }



}
