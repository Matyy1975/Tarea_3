using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;
    public GameObject meleeObject; // Referencia al objeto con la etiqueta "Melee"
    public int meleeDamage = 1; // Daño del ataque cuerpo a cuerpo
    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void MeleeAttack()
    {
        if (meleeObject != null)
        {
            meleeObject.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile") && collision.gameObject.transform.parent == null)
        {
            // Destruye la bala del enemigo
            Destroy(collision.gameObject);

            // Reduce la vida del jugador
            TakeDamage(1);
        }

        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            // Destruye el jugador cuando su vida llega a 0 o menos
            Destroy(gameObject);
        }
    }
}
