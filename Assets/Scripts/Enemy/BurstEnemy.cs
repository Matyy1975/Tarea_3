using System.Collections;
using UnityEngine;

public class BurstEnemy : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proyectil
    public Transform shootingPoint; // Punto de disparo
    public float projectileSpeed = 10f; // Velocidad del proyectil
    public float burstInterval = 2f; // Intervalo entre ráfagas
    public int burstCount = 3; // Cantidad de proyectiles en cada ráfaga

    private GameObject player; // Referencia al jugador
    private float nextBurstTime; // Tiempo para la próxima ráfaga

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.LogError("Player object not found!");
        }

        nextBurstTime = Time.time + burstInterval; // Establecer el tiempo para la próxima ráfaga
    }

    private void Update()
    {
        if (player == null)
        {
            return;
        }

        // Verificar si es el momento de realizar una ráfaga de disparos
        if (Time.time >= nextBurstTime)
        {
            // Calcular la dirección hacia el jugador
            Vector3 direction = player.transform.position - shootingPoint.position;
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);

            // Disparar ráfaga de proyectiles hacia la posición del jugador
            StartCoroutine(PerformBurst(direction.normalized, rotation));

            nextBurstTime = Time.time + burstInterval; // Actualizar el tiempo para la próxima ráfaga
        }
    }

    private IEnumerator PerformBurst(Vector3 direction, Quaternion rotation)
    {
        for (int i = 0; i < burstCount; i++)
        {
            // Instanciar el proyectil en el punto de disparo
            GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, rotation);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = direction * projectileSpeed;

            yield return new WaitForSeconds(0.1f); // Esperar un breve intervalo entre cada proyectil de la ráfaga
        }
    }
}
