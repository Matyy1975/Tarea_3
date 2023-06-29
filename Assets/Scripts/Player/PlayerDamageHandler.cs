using UnityEngine;

public class PlayerDamageHandler : MonoBehaviour
{
    public Color damageColor; // Color de destello al recibir daño
    public float damageDuration = 0.2f; // Duración del destello en segundos

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
            // Cambia el color del material del jugador al color de daño
            playerRenderer.material.color = damageColor;

            // Espera la duración del destello
            // Una forma sencilla de hacerlo sin utilizar corutinas sería utilizar el tiempo real
            // y compararlo con el tiempo en el que se recibió el daño
            if (Time.realtimeSinceStartup >= damageDuration)
            {
                // Restaura el color original del jugador
                playerRenderer.material.color = originalColor;

                // Reinicia la bandera de daño
                isDamaged = false;
            }
        }
    }

    public void TakeDamage()
    {
        if (!isDamaged)
        {
            // Activa la bandera de daño
            isDamaged = true;
        }
    }
}
