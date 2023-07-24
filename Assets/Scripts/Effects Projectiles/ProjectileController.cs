using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public GameObject explosionPrefab; // Referencia al GameObject que contiene la animación de explosión.
    private Animator animator;
    private bool collided = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si ya colisionó anteriormente o la colisión no fue con un objeto "wall", salimos.
        if (collided || !collision.gameObject.CompareTag("Wall"))
            return;

        // Detenemos el movimiento del proyectil.
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        // Obtén la posición de la colisión.
        Vector2 collisionPosition = collision.contacts[0].point;

        // Crea la animación de explosión en la posición de la colisión.
        GameObject explosion = Instantiate(explosionPrefab, collisionPosition, Quaternion.identity);

        // Inicia la animación de explosión.
        animator.SetBool("Explode", true);

        // Desactivamos el collider para evitar colisiones adicionales mientras se reproduce la animación.
        GetComponent<Collider2D>().enabled = false;

        // Marcamos que ya colisionó para no repetir la lógica en futuras colisiones.
        collided = true;

        // Destruimos el GameObject del proyectil después de que termine la animación.
        Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
    }
}
