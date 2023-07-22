using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Animator animator;
    private Animator playerAnimator;

    private void Start()
    {
        // Obtener el componente Animator del jugador
        animator = GetComponent<Animator>();
        playerAnimator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Comprobar si la colisión es con un objeto que tenga el tag "Projectile"
        if (collision.gameObject.CompareTag("Projectile") || (collision.gameObject.CompareTag("Projectile 2")) || (collision.gameObject.CompareTag("Projectile 3")) || (collision.gameObject.CompareTag("Area Damage")))
        {
            // Activar el parámetro tipo trigger "Inj" en el Animator
            animator.SetTrigger("Inj");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object has the "Hits" tag and is a child of an enemy
        if (collision.CompareTag("Hits") && collision.transform.parent != null && collision.transform.parent.CompareTag("Enemy"))
        {
            // Set the "Inj" trigger for the player to true, activating the animation state
            playerAnimator.SetTrigger("Inj");
        }
    }
}
