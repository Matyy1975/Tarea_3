using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    public GameObject explosionPrefab; // Referencia al GameObject que contiene la animaci�n de explosi�n.

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si la colisi�n fue con otro proyectil.
        if (collision.gameObject.CompareTag("Projectile") || (collision.gameObject.CompareTag("Projectile 2")) || (collision.gameObject.CompareTag("Projectile 3")) || (collision.gameObject.CompareTag("Training Projectile")))
        {
            // Obt�n la posici�n de la colisi�n.
            Vector2 collisionPosition = collision.contacts[0].point;

            // Crea la animaci�n de explosi�n en la posici�n de la colisi�n.
            GameObject explosion = Instantiate(explosionPrefab, collisionPosition, Quaternion.identity);

            // Inicia la animaci�n de explosi�n.
            explosion.GetComponent<Animator>().SetBool("Explode", true);

            // Destruye los proyectiles que colisionaron.
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
