using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab del proyectil
    public Transform shootingPoint; // Punto de disparo
    public float projectileSpeed = 10f; // Velocidad del proyectil
    public int minStoredProjectiles = 1; // Cantidad mínima de proyectiles absorbidos requeridos para disparar

    public ProjectileDeflector deflector; // Referencia al script ProjectileDeflector

    private AudioSource playerAudioSource; // Referencia al AudioSource del jugador

    private void Start()
    {
        if (deflector == null)
        {
            deflector = FindObjectOfType<ProjectileDeflector>(); // Encuentra automáticamente el objeto con el script ProjectileDeflector si no se ha asignado manualmente.
            if (deflector == null)
            {
                Debug.LogError("ProjectileDeflector script not found on the player!");
            }
        }

        playerAudioSource = GetComponent<AudioSource>(); // Obtener el AudioSource del jugador
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
                deflector.projectilesText.text = "" + deflector.storedProjectiles.ToString();
            }
        }
    }

    private void ShootProjectile()
    {
        // Obtener la dirección hacia la posición del mouse
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - shootingPoint.position;
        direction.z = 0f;

        // Crear el proyectil
        GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, Quaternion.identity);

        // Obtener el componente Rigidbody2D del proyectil
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // Aplicar la velocidad en la dirección especificada
        rb.velocity = direction.normalized * projectileSpeed;

        // Reproducir el sonido del proyectil
        if (playerAudioSource && projectile.GetComponent<AudioSource>())
        {
            projectile.GetComponent<AudioSource>().PlayOneShot(playerAudioSource.clip);
        }
    }
}
