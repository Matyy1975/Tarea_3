using UnityEngine;

public class IncreaseMaxHP : MonoBehaviour
{
    public int increaseAmount = 10; // Cantidad de aumento de HP máximo

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Obtener referencia al script PlayerController
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

            if (playerController != null)
            {
                // Aumentar el HP máximo del jugador
                playerController.IncreaseMaxHP(increaseAmount);

                // Destruir el objeto que aumenta el HP máximo
                Destroy(gameObject);
            }
        }
    }
}
