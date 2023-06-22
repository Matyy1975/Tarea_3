using UnityEngine;

public class Missile : MonoBehaviour
{
    public float speed = 5f; // Velocidad del proyectil
    public float rotationSpeed = 200f; // Velocidad de rotación del proyectil
    private Transform target; // Transform del jugador

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (target != null)
        {
            // Calcular dirección hacia el jugador
            Vector2 direction = target.position - transform.position;
            direction.Normalize();

            // Mover el proyectil hacia el jugador
            transform.Translate(direction * speed * Time.deltaTime, Space.World);

            // Calcular la rotación Z hacia el jugador
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, angle - 90f);

            // Rotar el proyectil hacia la dirección del movimiento
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
