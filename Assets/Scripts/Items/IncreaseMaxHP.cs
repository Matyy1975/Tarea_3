using UnityEngine;

public class IncreaseMaxHP : MonoBehaviour
{
    public int increaseAmount = 10; // Cantidad de aumento de HP m�ximo

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Obtener referencia al script PlayerController
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

            if (playerController != null)
            {
                // Aumentar el HP m�ximo del jugador
                playerController.IncreaseMaxHP(increaseAmount);

                // Destruir el objeto que aumenta el HP m�ximo
                Destroy(gameObject);
            }
        }
    }
}
