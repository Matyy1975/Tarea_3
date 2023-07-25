#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootingPoint;
    public float projectileSpeed = 10f;
    public float shootingRange = 5f; // Rango de disparo
    public float shootingInterval = 2f; // Intervalo entre disparos

    //public int damageReflected = 10; // Daño individual del enemigo

    private GameObject player;
    private EnemyHealth enemyHealth; // Referencia a EnemyHealth para aplicar el daño
    private float shootingTimer; // Temporizador para controlar la frecuencia de disparo
    private Animator animator; // Referencia al componente Animator del enemigo

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemyHealth = GetComponent<EnemyHealth>();

        if (player == null)
        {
            Debug.LogError("Player object not found!");
        }

        shootingTimer = shootingInterval; // Inicializar el temporizador con el intervalo de disparo
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (player == null)
        {
            return;
        }

        // Verificar si el jugador está dentro del rango de disparo
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
            Destroy(gameObject); // Destruir el enemigo si el proyectil y el enemigo tienen la misma posición
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
            // Aplicar daño al enemigo
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(10);
            }
            Destroy(collision.gameObject);
        }
        else if (collision.transform.CompareTag("Projectile 2"))
        {
            // Aplicar daño al enemy 3
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(25);
            }
            Destroy(collision.gameObject);
        }
        else if (collision.transform.CompareTag("Projectile 3"))
        {
            // Aplicar daño al enemy 4
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(30);
            }
            Destroy(collision.gameObject);
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, Vector3.forward, shootingRange);
    }
    public void DestroyEnemyWithAnimation()
    {
        // Puedes agregar cualquier lógica de destrucción específica del enemigo aquí.

        // Activar la animación de destrucción
        animator.SetTrigger("Destroy");
    }
#endif
}
