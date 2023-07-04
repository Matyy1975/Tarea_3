using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    public static ScoreManager scoreManager;
    public Image healthSlider; // Referencia al Slider de la barra de vida

    private void Start()
    {
        currentHealth = maxHealth;
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            // Obtén la referencia al componente EnemyScore
            EnemyScore enemyScoreComponent = GetComponent<EnemyScore>();

            if (enemyScoreComponent != null && scoreManager != null)
            {
                scoreManager.AddScore(enemyScoreComponent.enemyScore);
            }

        }

        UpdateHealthUI();
    }

    private void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            healthSlider.fillAmount = (float)currentHealth / maxHealth;
        }
    }
}
