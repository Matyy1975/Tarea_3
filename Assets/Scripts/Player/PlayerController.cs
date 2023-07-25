using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Image BarradeVida;
    public int maxHealth = 3;
    private int currentHealth;
    //public GameObject meleeObject; // Referencia al objeto con la etiqueta "Melee"
    public int reflectedDamage = 0; // Daño reflejado al enemigo
    public GameObject gameOverObject;
    private ScoreManager scoreManager;

    public GameObject scoreManagerObject;
    private void Start()
    {
        currentHealth = maxHealth;
        scoreManager = scoreManagerObject.GetComponent<ScoreManager>();
    }

    //public void MeleeAttack()
    //{
     //   if (meleeObject != null)
      //  {
       //     meleeObject.SetActive(true);
        //}
   // }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.otherCollider.CompareTag("Player")) { 
            if (collision.gameObject.CompareTag("Projectile") && collision.gameObject.transform.parent == null)
            {
                // Destruye la bala del enemigo
                Destroy(collision.gameObject);

                // Reduce la vida del jugador
                TakeDamage(10);
            }
            //PROJECTIL 2 PARRA EL ENEMIGO 3 
            if (collision.gameObject.CompareTag("Projectile 2") && collision.gameObject.transform.parent == null)
            {
                // Destruye la bala del enemigo
                Destroy(collision.gameObject);

                // Reduce la vida del jugador
                TakeDamage(25);
            }
            if (collision.gameObject.CompareTag("Projectile 3") && collision.gameObject.transform.parent == null)
            {
                // Destruye la bala del enemigo
                Destroy(collision.gameObject);

                // Reduce la vida del jugador
                TakeDamage(30);
            }
            //  if (collision.gameObject.CompareTag("Hits"))
            //{
            //  EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            //if (enemyHealth != null)
            //{
            //   enemyHealth.TakeDamage(reflectedDamage);
            //  Destroy(collision.gameObject); // Destruye el objeto de colisión (ataque del enemigo)
            //}
            //}
        }
    }

    public void ActivarGameOver()
    {
        // Activar la pantalla de Game Over
        if (gameOverObject != null)
        {
            gameOverObject.SetActive(true);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            // Destruye el jugador cuando su vida llega a 0 o menos
            BarradeVida.fillAmount = (1.0f * currentHealth) / maxHealth;
            ActivarGameOver();
            Destroy(gameObject);
            scoreManager.ResetScore();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void IncreaseMaxHP(int increaseAmount)
    {
        maxHealth += increaseAmount;
    }

    void Update()
    {
        BarradeVida.fillAmount = (1.0f * currentHealth) / maxHealth;
        // Leer las entradas del jugador para mover el personaje

        // Luego, llamar al método para mover la cámara junto con el jugador
        //cameraController.target = transform;
    }

}
