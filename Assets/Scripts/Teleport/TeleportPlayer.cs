using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public Transform teleportTarget; // El objeto con la posición a la que se teleportará el jugador

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Teletransportar al jugador a la posición del teleportTarget
            collision.gameObject.transform.position = teleportTarget.position;
        }
    }
}
