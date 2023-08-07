using System.Collections;
using UnityEngine;

public class EnemyMultipleShot : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proyectil
    public Transform shootingPoint; // Punto de disparo
    public int numberOfProjectiles = 5; // Cantidad de proyectiles a disparar
    public float projectileSpeed = 10f; // Velocidad del proyectil
    public float shootingInterval = 2f; // Intervalo entre disparos
    public float shootingRange = 5f; // Rango de disparo
    public float shootingDuration = 2f; // Duraci�n del tiempo de disparo
    public float shootingCooldown = 10f; // Tiempo de espera antes de poder disparar nuevamente

    private bool isShooting = false;

    private void Start()
    {
        // Llamamos a la corutina "AttackRoutine" para controlar el patr�n de disparo
        StartCoroutine(AttackRoutine());
    }

    private IEnumerator AttackRoutine()
    {
        while (true)
        {
            // Esperar el tiempo de cooldown antes de poder disparar nuevamente
            yield return new WaitForSeconds(shootingCooldown);

            // Disparar
            Shoot();

            // Activar el trigger del collider
            GetComponent<Collider2D>().isTrigger = true;

            // Esperar el tiempo de disparo
            yield return new WaitForSeconds(shootingDuration);

            // Desactivar el trigger del collider
            GetComponent<Collider2D>().isTrigger = false;

            // Esperar el tiempo de intervalo entre disparos
            yield return new WaitForSeconds(shootingInterval);
        }
    }

    private void Shoot()
    {
        // Obtener la direcci�n hacia la posici�n del jugador (o la direcci�n deseada)
        Vector3 playerPosition = GetPlayerPosition(); // Implementa esta funci�n seg�n la l�gica de tu juego
        Vector3 direction = playerPosition - transform.position;
        direction.z = 0f;

        // Calcular el �ngulo entre los proyectiles
        float angleStep = 360f / numberOfProjectiles;

        // Crear m�ltiples proyectiles en diferentes direcciones
        for (int i = 0; i < numberOfProjectiles; i++)
        {
            // Calcular la direcci�n del proyectil actual
            Quaternion rotation = Quaternion.Euler(0f, 0f, angleStep * i);
            Vector3 projectileDirection = rotation * direction.normalized;

            // Crear el proyectil
            GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, Quaternion.identity);

            // Obtener el componente Rigidbody2D del proyectil
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            // Aplicar la velocidad en la direcci�n especificada
            rb.velocity = projectileDirection.normalized * projectileSpeed;
        }
    }

    private Vector3 GetPlayerPosition()
    {
        // Implementa la l�gica para obtener la posici�n del jugador aqu�
        // Puedes utilizar, por ejemplo, GameObject.FindWithTag("Player") para encontrar al jugador por su tag
        // En este ejemplo, simplemente retornamos la posici�n del (0,0,0) para que los proyectiles salgan desde el centro del enemigo
        return Vector3.zero;
    }

    // Dibujar un gizmo visualizando el rango de disparo en el editor
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
