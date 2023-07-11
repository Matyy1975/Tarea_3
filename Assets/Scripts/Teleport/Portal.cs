using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform teleportPoint;
    private bool canTeleport = true;
    private Vector2 initialDirection;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D projectileRigidbody = other.GetComponent<Rigidbody2D>();

        if (projectileRigidbody != null)
        {
            if (canTeleport)
            {
                // Obtener la direcci�n de movimiento actual del proyectil
                Vector2 direction = projectileRigidbody.velocity.normalized;

                // Teletransportar el proyectil al punto de teletransporte
                projectileRigidbody.position = teleportPoint.position;

                // Aplicar la misma direcci�n al proyectil despu�s de teletransportarlo
                projectileRigidbody.velocity = direction * projectileRigidbody.velocity.magnitude;

                canTeleport = false;
                initialDirection = direction;
            }
            else if (initialDirection != Vector2.zero)
            {
                // Teletransportar el proyectil nuevamente al punto de teletransporte
                projectileRigidbody.position = teleportPoint.position;

                // Aplicar la direcci�n inicial al proyectil despu�s de teletransportarlo
                projectileRigidbody.velocity = initialDirection * projectileRigidbody.velocity.magnitude;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Rigidbody2D projectileRigidbody = other.GetComponent<Rigidbody2D>();

        if (projectileRigidbody != null)
        {
            canTeleport = true;
            initialDirection = Vector2.zero;
        }
    }
}
