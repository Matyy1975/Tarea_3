using UnityEngine;
using TMPro;

public class ProjectileDeflector : MonoBehaviour
{
    public float deflectionSpeed = 10f; // Velocidad de desviación de los proyectiles
    public int maxStoredProjectiles = 3; // Cantidad máxima de proyectiles absorbidos que puede almacenar
    public int storedProjectiles = 0; // Cantidad actual de proyectiles absorbidos
    public TextMeshProUGUI projectilesText;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            // Absorber el proyectil
            Destroy(collision.gameObject);

            // Incrementar el contador de proyectiles absorbidos
            storedProjectiles++;
            //Debug.Log("Se Guardo "+(storedProjectiles));

            // Realizar acciones adicionales al absorber el proyectil

            // Desviar el proyectil
            Vector3 direction = collision.gameObject.transform.position - transform.position;
            Rigidbody2D projectileRb = collision.gameObject.GetComponent<Rigidbody2D>();
            projectileRb.velocity = direction.normalized * deflectionSpeed;
        }
    }

    public void ShootProjectile()
    {
        if (storedProjectiles > 0)
        {
            // Disparar un proyectil (realizar las acciones correspondientes)

            // Reducir el contador de proyectiles absorbidos
            storedProjectiles--;
        }
    }
      void Update()
    {
        // Actualizar el texto del objeto de texto con la cantidad actual de proyectiles
        projectilesText.text = "" + storedProjectiles.ToString();
    }
}
