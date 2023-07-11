using UnityEngine;

public class Projectile : MonoBehaviour
{

    private void Start()
    {
        // Obtener todos los colliders del jugador
        Collider2D[] playerColliders = GameObject.FindGameObjectWithTag("Player").GetComponentsInChildren<Collider2D>();

        // Ignorar las colisiones con los colliders del jugador
        foreach (Collider2D playerCollider in playerColliders)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), playerCollider);
        }
    }

    // Resto del código del proyectil...
}
