using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage = 10f;

    private void Start()
    {
        // Obtener todos los colliders del jugador
        Collider2D[] playerColliders = GameObject.FindGameObjectWithTag("Player").GetComponentsInChildren<Collider2D>();

        // Ignorar las colisiones con los colliders del jugador
        foreach (Collider2D playerCollider in playerColliders)
        {
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), playerCollider);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Melee") || collision.gameObject.CompareTag("Enemy"))
        {
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                int damageInt = Mathf.RoundToInt(damage);
                enemyHealth.TakeDamage(damageInt);
            }

            Destroy(gameObject);
        }
    }

    // Resto del código del proyectil...
}
