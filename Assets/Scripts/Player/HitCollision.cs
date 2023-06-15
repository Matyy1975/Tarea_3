using UnityEngine;

public class HitCollision : MonoBehaviour
{
    public float recoilForce = 2f;
    public bool isStoppedOnCollision = true;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Melee"))
        {
            // Calcula la dirección del retroceso
            Vector2 recoilDirection = transform.position - collision.gameObject.transform.position;
            recoilDirection.Normalize();

            // Aplica el retroceso al enemigo
            rb.AddForce(recoilDirection * recoilForce, ForceMode2D.Impulse);

            if (isStoppedOnCollision)
            {
                // Detiene el movimiento del enemigo
                rb.velocity = Vector2.zero;
            }
        }
    }
}
