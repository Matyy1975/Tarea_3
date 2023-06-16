using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damageAmount = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Accede al script PlayerController del jugador
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

            if (playerController != null)
            {
                // Causa daño al jugador
                playerController.TakeDamage(damageAmount);
            }
        }
    }
}
