using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;

    private Vector2 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        // Si quieres restringir el movimiento dentro de los l�mites de la pantalla,
        // descomenta las siguientes l�neas y aseg�rate de tener un objeto con un BoxCollider2D
        // que represente los l�mites de la pantalla.

        // float clampedX = Mathf.Clamp(rb.position.x, minX, maxX);
        // float clampedY = Mathf.Clamp(rb.position.y, minY, maxY);
        // rb.MovePosition(new Vector2(clampedX, clampedY));
    }
}
