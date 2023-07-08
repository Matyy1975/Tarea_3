using UnityEngine;

public class ObjectInteraction : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proyectil
    public Transform shootingPoint; // Punto de disparo
    public float projectileSpeed = 10f; // Velocidad del proyectil
    public KeyCode interactionKey = KeyCode.E; // Tecla de interacción

    private PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();

        if (playerController == null)
        {
            Debug.LogError("PlayerController component not found in the scene!");
        }
    }

    private void Update()
    {
        // Verificar si el jugador presiona la tecla de interacción
        if (Input.GetKeyDown(interactionKey))
        {
            // Obtener la dirección hacia el jugador
            Vector3 direction = (playerController.transform.position - shootingPoint.position).normalized;

            // Disparar el proyectil en la dirección calculada
            ShootProjectile(direction);
        }
    }

    private void ShootProjectile(Vector3 direction)
    {
        // Crear el proyectil
        GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, Quaternion.identity);

        // Obtener el componente Rigidbody2D del proyectil
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // Aplicar la velocidad en la dirección especificada
        rb.velocity = direction * projectileSpeed;
    }
}
