    using UnityEngine;

    public class ObjectReflection : MonoBehaviour
    {
        public float speed;


    private void OnTriggerEnter2D(Collider2D collision)
        {
        if (collision.gameObject.CompareTag("Projectile") || collision.gameObject.CompareTag("Projectile 2" ) || collision.gameObject.CompareTag("Projectile 3") || collision.gameObject.CompareTag("Training Projectile"))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            Vector3 direction = mousePosition - transform.position;

            // Aplica la nueva direcci�n al objeto
            // Puedes utilizar rb.velocity = reflectedDirection.normalized * speed; si el objeto tiene un Rigidbody2D y deseas aplicar una velocidad constante
            // ransform.up = reflectedDirection.normalized;

            // Debug.Log(collision.transform.name, collision.transform);
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = direction.normalized * speed;
            collision.gameObject.transform.localScale = new Vector3(collision.gameObject.transform.localScale.x, collision.gameObject.transform.localScale.y * -1, collision.gameObject.transform.localScale.z);

            if (collision.GetComponent<Missile>() != null)
            {
                collision.GetComponent<Missile>().enabled = false;
            }
        }

    }
}
    
