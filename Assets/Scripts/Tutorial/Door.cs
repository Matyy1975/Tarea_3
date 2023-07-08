using UnityEngine;

public class Door : MonoBehaviour
{
    public int maxCount = 3; // Cantidad máxima de colisiones permitidas antes de desactivar la puerta
    private int currentCount; // Cantidad actual de colisiones

    private void Start()
    {
        currentCount = maxCount; // Inicializar el conteo con el valor máximo
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Training Projectile"))
        {
            // Restar 1 al conteo
            currentCount--;

            // Verificar si el conteo ha llegado a cero
            if (currentCount <= 0)
            {
                // Desactivar la puerta
                gameObject.SetActive(false);
            }
        }
    }
}
