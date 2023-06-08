using UnityEngine;

public class ObjectReflection : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            Vector3 direction = mousePosition - transform.position;
            Vector3 reflectedDirection = Vector3.Reflect(direction.normalized, collision.contacts[0].normal);

            // Aplica la nueva dirección al objeto
            // Puedes utilizar rb.velocity = reflectedDirection.normalized * speed; si el objeto tiene un Rigidbody2D y deseas aplicar una velocidad constante
            transform.up = reflectedDirection.normalized;
        }
    }
}
