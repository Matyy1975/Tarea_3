using UnityEngine;

public class AreaAttackEnemy : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proyectil
    public GameObject areaDamagePrefab; // Prefab del da�o en �rea
    public Transform player; // Referencia al transform del jugador
    public float projectileSpeed = 5f; // Velocidad del proyectil
    public float projectileLifetime = 2f; // Tiempo de vida del proyectil
    public float areaDamageDuration = 3f; // Duraci�n del da�o en �rea

    private bool isAttacking; // Indica si el enemigo est� atacando
    private float attackStartTime; // Tiempo de inicio del ataque
    private Vector3 areaDamagePos;
    private void Update()
    {
        // Calcular la direcci�n hacia el jugador
        Vector3 direction = player.position - transform.position;

        if (!isAttacking && direction.magnitude > 0.1f)
        {
            // Iniciar el ataque
            isAttacking = true;
            attackStartTime = Time.time;

            // Invocar objeto de �rea de ataque
            GameObject areaDamage = Instantiate(areaDamagePrefab, player.position, Quaternion.identity);
            areaDamagePos = areaDamage.transform.position;

            Destroy(areaDamage, areaDamageDuration);

            // Realizar disparo al final del tiempo de duraci�n del �rea de ataque
            Invoke("PerformProjectileAttack", areaDamageDuration);
        }
    }

    private void PerformProjectileAttack()
    {
        if (isAttacking)
        {
            // Calcular la direcci�n hacia el jugador
            Vector3 direction = player.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);

            // Obtener el punto de disparo del �rea de da�o
            Vector3 shootingPoint = areaDamagePos;

            // Disparar el proyectil desde el punto de disparo hacia la posici�n del jugador
            GameObject projectile = Instantiate(projectilePrefab, shootingPoint, rotation);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = direction.normalized * projectileSpeed;
            Destroy(projectile, projectileLifetime);

            // Reiniciar el ataque
            isAttacking = false;
        }
    }
}
