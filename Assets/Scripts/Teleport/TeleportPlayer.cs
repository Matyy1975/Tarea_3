using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public Transform teleportTarget; // El objeto con la posici�n a la que se teleportar� el jugador

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Teletransportar al jugador a la posici�n del teleportTarget
            collision.gameObject.transform.position = teleportTarget.position;
        }
    }
}
