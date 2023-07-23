using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    public GameObject explosionPrefab; // Referencia al GameObject que contiene la animación de explosión.

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si la colisión fue con otro proyectil.
        if (collision.gameObject.CompareTag("Projectile") || (collision.gameObject.CompareTag("Projectile 2")) || (collision.gameObject.CompareTag("Projectile 3")) || (collision.gameObject.CompareTag("Training Projectile")))
        {
            // Obtén la posición de la colisión.
            Vector2 collisionPosition = collision.contacts[0].point;

            // Crea la animación de explosión en la posición de la colisión.
            GameObject explosion = Instantiate(explosionPrefab, collisionPosition, Quaternion.identity);

            // Inicia la animación de explosión.
            explosion.GetComponent<Animator>().SetBool("Explode", true);

            // Destruye los proyectiles que colisionaron.
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
