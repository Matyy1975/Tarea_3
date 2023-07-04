using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthAmount = 1; // Cantidad de vida a recuperar

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Obtener referencia al script PlayerController
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                // Recuperar vida del objeto tocado por el jugador
                playerController.Heal(healthAmount);

                // Destruir el objeto de recuperación de vida
                Destroy(gameObject);
            }
        }
    }
}
