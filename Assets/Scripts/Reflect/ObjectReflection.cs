using UnityEngine;

public class ObjectReflection : MonoBehaviour
{
    public float speed; // Velocidad de reflexión

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si la colisión es con un objeto que tenga las etiquetas "Projectile"
        if (collision.gameObject.CompareTag("Projectile"))
        {
            // Obtiene la posición del mouse en el mundo
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            // Calcula la dirección hacia la posición del mouse desde el objeto actual
            Vector3 direction = mousePosition - transform.position;

            // Obtiene el componente Rigidbody2D del objeto en colisión
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            // Aplica la nueva velocidad al objeto en colisión en la dirección calculada
            rb.velocity = direction.normalized * speed;

            // Invierte la escala del objeto en colisión en el eje Y para reflejarlo verticalmente
            collision.gameObject.transform.localScale = new Vector3(collision.gameObject.transform.localScale.x, collision.gameObject.transform.localScale.y * -1, collision.gameObject.transform.localScale.z);

            
        }
    }
}
