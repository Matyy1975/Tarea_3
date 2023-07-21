using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        // Obtener el componente Animator del jugador
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Comprobar si la colisión es con un objeto que tenga el tag "Projectile"
        if (collision.gameObject.CompareTag("Projectile"))
        {
            // Activar el parámetro tipo trigger "Inj" en el Animator
            animator.SetTrigger("Inj");
        }
    }
}
