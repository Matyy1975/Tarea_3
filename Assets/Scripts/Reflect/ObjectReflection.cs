    using UnityEngine;

    public class ObjectReflection : MonoBehaviour
    {
        public float speed;
    
        private void OnCollisionEnter2D(Collision2D collision)
        {    
            if (collision.gameObject.CompareTag("Projectile"))
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0f;

                Vector3 direction = mousePosition - transform.position;

                // Aplica la nueva dirección al objeto
                // Puedes utilizar rb.velocity = reflectedDirection.normalized * speed; si el objeto tiene un Rigidbody2D y deseas aplicar una velocidad constante
                // ransform.up = reflectedDirection.normalized;

                Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
                rb.velocity = direction.normalized * speed;
            }
        }
    }
