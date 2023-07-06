using UnityEngine;

public class DamageObject : MonoBehaviour
{
    public int damageAmount = 10; // Cantidad de da�o a infligir

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Obt�n una referencia al script PlayerController
            PlayerController playerController = collision.GetComponent<PlayerController>();

            if (playerController != null)
            {
                // Aplica el da�o al jugador
                playerController.TakeDamage(damageAmount);
            }
        }
    }
}
