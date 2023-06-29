using UnityEngine;

public class PlayerDamageHandler : MonoBehaviour
{
    public Color damageColor; // Color de destello al recibir da�o
    public float damageDuration = 0.2f; // Duraci�n del destello en segundos

    private Renderer playerRenderer;
    private Color originalColor;
    private bool isDamaged = false;

    private void Start()
    {
        playerRenderer = GetComponent<Renderer>();
        originalColor = playerRenderer.material.color;
    }

    private void Update()
    {
        if (isDamaged)
        {
            // Cambia el color del material del jugador al color de da�o
            playerRenderer.material.color = damageColor;

            // Espera la duraci�n del destello
            // Una forma sencilla de hacerlo sin utilizar corutinas ser�a utilizar el tiempo real
            // y compararlo con el tiempo en el que se recibi� el da�o
            if (Time.realtimeSinceStartup >= damageDuration)
            {
                // Restaura el color original del jugador
                playerRenderer.material.color = originalColor;

                // Reinicia la bandera de da�o
                isDamaged = false;
            }
        }
    }

    public void TakeDamage()
    {
        if (!isDamaged)
        {
            // Activa la bandera de da�o
            isDamaged = true;
        }
    }
}
