using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proyectil
    public Transform shootingPoint; // Punto de disparo
    public float projectileSpeed = 10f; // Velocidad del proyectil
    public int minStoredProjectiles = 1; // Cantidad m�nima de proyectiles absorbidos requeridos para disparar

    public ProjectileDeflector deflector; // Referencia al script ProjectileDeflector

    private void Start()
    {

        if (deflector == null)
        {
            Debug.LogError("ProjectileDeflector script not found on the player!");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (deflector.storedProjectiles >= minStoredProjectiles)
            {
                ShootProjectile();
                deflector.storedProjectiles--;
                Debug.Log("Descontando " + deflector.storedProjectiles);
            }
        }
    }

    private void ShootProjectile()
    {
        // Obtener la direcci�n hacia la posici�n del mouse
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - shootingPoint.position;
        direction.z = 0f;

        // Crear el proyectil
        GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, Quaternion.identity);

        // Obtener el componente Rigidbody2D del proyectil
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // Aplicar la velocidad en la direcci�n especificada
        rb.velocity = direction.normalized * projectileSpeed;
    }
}
