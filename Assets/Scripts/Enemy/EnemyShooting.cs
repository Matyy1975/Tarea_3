using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootingPoint;
    public float projectileSpeed = 10f;

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.LogError("Player object not found!");
        }
        else
        {
            InvokeRepeating("FireProjectile", 0f, 2f); // Dispara un proyectil cada 2 segundos (puedes ajustar este intervalo)
        }
    }

    private void FireProjectile()
    {
        if (player == null)
        {
            return;
        }

        Vector3 direction = player.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);

        GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = direction.normalized * projectileSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
