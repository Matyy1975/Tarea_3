using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            // Destruye la bala del enemigo
            Destroy(collision.gameObject);

            // Destruye el jugador cuando colisiona con el proyectil del enemigo
            Destroy(gameObject);
        }
    }
}
