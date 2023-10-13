using UnityEngine;

public class ObjectReflection : MonoBehaviour
{
    public float speed; // Velocidad de reflexi�n

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si la colisi�n es con un objeto que tenga las etiquetas "Projectile"
        if (collision.gameObject.CompareTag("Projectile"))
        {
            // Obtiene la posici�n del mouse en el mundo
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0f;

            // Calcula la direcci�n hacia la posici�n del mouse desde el objeto actual
            Vector3 direction = mousePosition - transform.position;

            // Obtiene el componente Rigidbody2D del objeto en colisi�n
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();

            // Aplica la nueva velocidad al objeto en colisi�n en la direcci�n calculada
            rb.velocity = direction.normalized * speed;

            // Invierte la escala del objeto en colisi�n en el eje Y para reflejarlo verticalmente
            collision.gameObject.transform.localScale = new Vector3(collision.gameObject.transform.localScale.x, collision.gameObject.transform.localScale.y * -1, collision.gameObject.transform.localScale.z);

            
        }
    }
}
