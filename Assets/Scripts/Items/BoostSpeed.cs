using UnityEngine;

public class BoostSpeed : MonoBehaviour
{
    public float speedBoostAmount = 5f; // Cantidad de aumento de velocidad
    public float speedBoostDuration = 5f; // Duración del aumento de velocidad en segundos

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Obtener el componente PlayerMovement del objeto jugador
            PlayerMovement playerMovement = collision.GetComponent<PlayerMovement>();

            // Verificar si se encontró el componente PlayerMovement
            if (playerMovement != null)
            {
                // Aumentar la velocidad del jugador temporalmente
                playerMovement.StartSpeedBoost(speedBoostAmount, speedBoostDuration);

                // Desactivar este objeto después de la colisión
                gameObject.SetActive(false);
            }
        }
    }
}
