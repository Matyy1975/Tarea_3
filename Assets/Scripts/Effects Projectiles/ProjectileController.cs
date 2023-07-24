using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public GameObject explosionPrefab; // Referencia al GameObject que contiene la animaci�n de explosi�n.
    private Animator animator;
    private bool collided = false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si ya colision� anteriormente o la colisi�n no fue con un objeto "wall", salimos.
        if (collided || !collision.gameObject.CompareTag("Wall"))
            return;

        // Detenemos el movimiento del proyectil.
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        // Obt�n la posici�n de la colisi�n.
        Vector2 collisionPosition = collision.contacts[0].point;

        // Crea la animaci�n de explosi�n en la posici�n de la colisi�n.
        GameObject explosion = Instantiate(explosionPrefab, collisionPosition, Quaternion.identity);

        // Inicia la animaci�n de explosi�n.
        animator.SetBool("Explode", true);

        // Desactivamos el collider para evitar colisiones adicionales mientras se reproduce la animaci�n.
        GetComponent<Collider2D>().enabled = false;

        // Marcamos que ya colision� para no repetir la l�gica en futuras colisiones.
        collided = true;

        // Destruimos el GameObject del proyectil despu�s de que termine la animaci�n.
        Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
    }
}
