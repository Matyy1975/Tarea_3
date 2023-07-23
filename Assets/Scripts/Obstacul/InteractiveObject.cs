using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    public int damageAmount = 10; // Daño que se resta al jugador al tocar este objeto
    public float pushForce = 10f; // Fuerza de empuje del objeto

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Reduce la vida del jugador
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.TakeDamage(damageAmount);
            }

            // Obtiene la dirección del empuje y aplica fuerza al jugador
            Vector2 pushDirection = collision.transform.position - transform.position;
            pushDirection = pushDirection.normalized;
            Rigidbody2D playerRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();
            if (playerRigidbody != null)
            {
                playerRigidbody.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
            }
        }
    }
}
