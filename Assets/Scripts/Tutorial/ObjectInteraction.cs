using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proyectil
    public Transform shootingPoint; // Punto de disparo
    public float projectileSpeed = 10f; // Velocidad del proyectil
    public float shootingInterval = 2f; // Intervalo entre disparos

    private float shootingTimer; // Temporizador para controlar el intervalo entre disparos

    private void Start()
    {
        shootingTimer = shootingInterval; // Inicializar el temporizador con el intervalo de disparo
    }

    private void Update()
    {
        // Actualizar el temporizador
        shootingTimer -= Time.deltaTime;

        // Verificar si ha pasado el tiempo suficiente para disparar
        if (shootingTimer <= 0f)
        {
            // Reiniciar el temporizador
            shootingTimer = shootingInterval;

            // Disparar el proyectil
            ShootProjectile();
        }
    }

    private void ShootProjectile()
    {
        // Crear el proyectil
        GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, shootingPoint.rotation);

        // Obtener el componente Rigidbody2D del proyectil
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // Aplicar la velocidad en la dirección especificada
        rb.velocity = shootingPoint.right * projectileSpeed;
    }
}
