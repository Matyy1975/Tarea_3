using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public Image BarradeVida;
    public int maxHealth = 3;
    private int currentHealth;
    public GameObject meleeObject; // Referencia al objeto con la etiqueta "Melee"
    public int meleeDamage = 1; // Daño del ataque cuerpo a cuerpo
    public int reflectedDamage = 1; // Daño reflejado al enemigo
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
        if (collision.gameObject.CompareTag("Hits"))
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(reflectedDamage);
                Destroy(collision.gameObject); // Destruye el objeto de colisión (ataque del enemigo)
            }
        }

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            // Destruye el jugador cuando su vida llega a 0 o menos
            BarradeVida.fillAmount = (1.0f * currentHealth) / maxHealth;
            Destroy(gameObject);
        }
    }
    void Update()
    {
        BarradeVida.fillAmount = (1.0f * currentHealth) / maxHealth;
        // Leer las entradas del jugador para mover el personaje

        // Luego, llamar al método para mover la cámara junto con el jugador
        //cameraController.target = transform;
    }

}
