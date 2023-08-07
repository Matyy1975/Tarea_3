using UnityEngine;

public class MultiShotAttack : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proyectil
    public Transform shootingPoint; // Punto de disparo
    public int numberOfProjectiles = 8; // Cantidad de proyectiles a disparar alrededor

    public float projectileSpeed = 10f; // Velocidad del proyectil
    public float angleBetweenProjectiles = 45f; // Ángulo entre cada proyectil

    public void Attack()
    {
        for (int i = 0; i < numberOfProjectiles; i++)
        {
            // Calcular el ángulo para este proyectil
            float angle = i * angleBetweenProjectiles;

            // Calcular la dirección en la que se disparará el proyectil
            Vector3 direction = Quaternion.Euler(0, 0, angle) * Vector3.right;

            // Crear el proyectil
            GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, Quaternion.identity);

            // Obtener el componente Rigidbody2D del proyectil
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            // Aplicar la velocidad en la dirección especificada
            rb.velocity = direction.normalized * projectileSpeed;
        }
    }
}
