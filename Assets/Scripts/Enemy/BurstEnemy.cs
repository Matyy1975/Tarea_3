using System.Collections;
using UnityEngine;

public class BurstEnemy : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proyectil
    public Transform shootingPoint; // Punto de disparo
    public float projectileSpeed = 10f; // Velocidad del proyectil
    public float burstInterval = 2f; // Intervalo entre r�fagas
    public int burstCount = 3; // Cantidad de proyectiles en cada r�faga
    public float shootingPointOffset = 1f; // Desplazamiento del punto de disparo

    private GameObject player; // Referencia al jugador
    private float nextBurstTime; // Tiempo para la pr�xima r�faga
    private EnemyHealth enemyHealth; // Referencia al script EnemyHealth

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.LogError("Player object not found!");
        }

        nextBurstTime = Time.time + burstInterval; // Establecer el tiempo para la pr�xima r�faga
        enemyHealth = GetComponent<EnemyHealth>(); // Obtener referencia al script EnemyHealth
    }

    private void Update()
    {
        if (player == null)
        {
            return;
        }

        // Verificar si es el momento de realizar una r�faga de disparos
        if (Time.time >= nextBurstTime)
        {
            // Calcular la direcci�n hacia el jugador
            Vector3 direction = player.transform.position - shootingPoint.position;
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);

            // Desactivar el collider del enemigo temporalmente
            Collider2D enemyCollider = GetComponent<Collider2D>();
            if (enemyCollider != null)
            {
                enemyCollider.enabled = false;
            }

            // Disparar r�faga de proyectiles hacia la posici�n del jugador
            StartCoroutine(PerformBurst(direction.normalized, rotation));

            // Activar el collider del enemigo nuevamente
            if (enemyCollider != null)
            {
                enemyCollider.enabled = true;
            }

            nextBurstTime = Time.time + burstInterval; // Actualizar el tiempo para la pr�xima r�faga
        }
    }

    private IEnumerator PerformBurst(Vector3 direction, Quaternion rotation)
    {
        for (int i = 0; i < burstCount; i++)
        {
            // Desplazar el punto de disparo hacia afuera del objeto
            Vector3 shootingPointPosition = shootingPoint.position + direction * shootingPointOffset;

            // Instanciar el proyectil en el punto de disparo
            GameObject projectile = Instantiate(projectilePrefab, shootingPointPosition, rotation);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = direction * projectileSpeed;

            yield return new WaitForSeconds(0.1f); // Esperar un breve intervalo entre cada proyectil de la r�faga
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Projectile 3"))
        {
            // Aplicar da�o al enemigo
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(30); // Llamar al m�todo TakeDamage del script EnemyHealth con el valor de da�o deseado
            }
            Destroy(collision.gameObject);
        }
    }
}
