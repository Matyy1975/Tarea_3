using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    // Animator reference
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Animator component attached to the GameObject
        animator = GetComponent<Animator>();
    }

    // OnCollisionEnter2D is called when the attached Collider2D component collides with another Collider2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has the "Projectile" tag
        if (collision.collider.CompareTag("Projectile"))
        {
            // Set the "Injunemy" trigger to true, activating the animation state
            animator.SetTrigger("Injunemy");
        }
        if (collision.collider.CompareTag("Projectile 3"))
        {
            // Set the "Injunemy" trigger to true, activating the animation state
            animator.SetTrigger("Inju4");
        }
    }
}
