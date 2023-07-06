using UnityEngine;

public class DamageObject : MonoBehaviour
{
    public int damageAmount = 10; // Cantidad de daño a infligir

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Obtén una referencia al script PlayerController
            PlayerController playerController = collision.GetComponent<PlayerController>();

            if (playerController != null)
            {
                // Aplica el daño al jugador
                playerController.TakeDamage(damageAmount);
            }
        }
    }
}
