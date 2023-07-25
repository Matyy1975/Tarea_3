using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    public static ScoreManager scoreManager;
    public Image healthSlider; // Referencia al Slider de la barra de vida
    private Animator animator; // Referencia al componente Animator del enemigo
    //public GameObject explosionEffect; // Referencia al objeto con la animación de explosión
    public GameObject explosionPrefab;

    private void Start()
    {
        currentHealth = maxHealth;
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        animator = GetComponent<Animator>();
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            DestroyEnemy();
        }

        UpdateHealthUI();
    }

    private void DestroyEnemy()
    {
        // Activar el efecto de explosión
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject, 5f); // Ajusta el valor 1f al tiempo que dure tu animación de explosión
        }
        

        // Obtén la referencia al componente EnemyScore
        EnemyScore enemyScoreComponent = GetComponent<EnemyScore>();

        if (enemyScoreComponent != null && scoreManager != null)
        {
            scoreManager.AddScore(enemyScoreComponent.enemyScore);
        }

        // Destruir el enemigo
        Destroy(gameObject);
    }

    private void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            healthSlider.fillAmount = (float)currentHealth / maxHealth;
        }
    }
    public void DestroyEnemyWithAnimation()
    {
        Debug.Log("DestroyEnemyWithAnimation() called!");
        // Activar la animación de destrucción
        animator.SetTrigger("Destroy");
    }
}
