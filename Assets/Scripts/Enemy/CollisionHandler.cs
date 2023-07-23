using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public string projectileTag = "Training Projectile";
    public string parameterName = "Inj Slime";

    private Animator animator;

    private void Start()
    {
        // Obtener el componente Animator del objeto que tiene este script
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Comprobar si el objeto que colision� tiene el tag "Training Projectile"
        if (collision.gameObject.CompareTag(projectileTag))
        {
            // Activar el par�metro "Inj Slime" como un Trigger en el Animator
            animator.SetTrigger(parameterName);
        }
    }
}
