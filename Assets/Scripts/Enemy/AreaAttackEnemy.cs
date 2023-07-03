using UnityEngine;

public class AreaAttackEnemy : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proyectil
    public Transform player; // Referencia al transform del jugador
    public float projectileSpeed = 5f; // Velocidad del proyectil
    public float projectileLifetime = 2f; // Tiempo de vida del proyectil

    private void Update()
    {
        // Calcular la dirección hacia el jugador
        Vector3 direction = player.position - transform.position;

        // Disparar el proyectil en la dirección del jugador
        if (direction.magnitude > 0.1f) // Verificar que el jugador esté lo suficientemente lejos
        {
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);
            GameObject projectile = Instantiate(projectilePrefab, transform.position, rotation);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = direction.normalized * projectileSpeed;
            Destroy(projectile, projectileLifetime);
        }
    }
}
