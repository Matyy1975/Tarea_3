using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    public int maxCount = 3; // Cantidad máxima de colisiones permitidas antes de desactivar la puerta
    private int currentCount; // Cantidad actual de colisiones
    public TextMeshProUGUI textMesh; // Referencia al objeto de texto en el Canvas

    private void Start()
    {
        currentCount = maxCount; // Inicializar el conteo con el valor máximo
        UpdateCountText(); // Actualizar el texto en el inicio
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

            UpdateCountText(); // Actualizar el texto después de cada colisión
        }
    }

    private void UpdateCountText()
    {
        textMesh.text = currentCount.ToString();
    }
}
