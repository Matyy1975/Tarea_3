using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootingPoint;
    public float projectileSpeed = 10f;
    public float shootingRange = 5f; // Rango de disparo
    public float shootingInterval = 2f; // Intervalo entre disparos

    private GameObject player;
    private EnemyHealth enemyHealth; // Referencia a EnemyHealth para aplicar el da�o
    private float shootingTimer; // Temporizador para controlar la frecuencia de disparo

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyHealth = GetComponent<EnemyHealth>();

        if (player == null)
        {
            Debug.LogError("Player object not found!");
        }

        shootingTimer = shootingInterval; // Inicializar el temporizador con el intervalo de disparo
    }

    private void Update()
    {
        if (player == null)
        {
            return;
        }

        // Verificar si el jugador est� dentro del rango de disparo
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer <= shootingRange)
        {
            // Actualizar el temporizador
            shootingTimer -= Time.deltaTime;

            if (shootingTimer <= 0f)
            {
                // Disparar proyectil y reiniciar el temporizador
                FireProjectile();
                shootingTimer = shootingInterval;
            }
        }
    }

    private void FireProjectile()
    {
        Vector3 direction = player.transform.position - shootingPoint.position;
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);

        // Verificar si el proyectil y el enemigo tienen la misma coordenada
        if (Mathf.Approximately(shootingPoint.position.x, player.transform.position.x) &&
            Mathf.Approximately(shootingPoint.position.y, player.transform.position.y))
        {
            Destroy(gameObject); // Destruir el enemigo si el proyectil y el enemigo tienen la misma posici�n
            return;
        }

        Vector3 offset = direction.normalized;

        GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position + offset * 0000001, rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = direction.normalized * projectileSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Projectile"))
        {
            // Aplicar da�o al enemigo
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(1);
            }
            Destroy(collision.gameObject);
        }
    }
}
