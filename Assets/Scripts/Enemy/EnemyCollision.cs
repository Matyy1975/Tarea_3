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
        //ANIMACION DE DA�O
        //ENEMY1
        // Check if the collided object has the "Projectile" tag
        if (collision.collider.CompareTag("Projectile") || collision.collider.CompareTag("Projectile 2") || collision.collider.CompareTag("Projectile 3")|| collision.collider.CompareTag("Training Projectile"))
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
