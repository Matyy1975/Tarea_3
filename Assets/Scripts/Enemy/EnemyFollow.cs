using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public Transform player; // Referencia al Transform del jugador
    public float followSpeed = 5f; // Velocidad de seguimiento del enemigo

    // Update is called once per frame
    void Update()
    {
        // Verificar que el jugador no sea nulo (exista en la escena)
        if (player != null)
        {
            // Calcular la dirección hacia el jugador
            Vector3 directionToPlayer = player.position - transform.position;
            directionToPlayer.Normalize();

            // Calcular la cantidad de movimiento en cada frame
            Vector3 movement = directionToPlayer * followSpeed * Time.deltaTime;

            // Mover el enemigo hacia el jugador
            transform.Translate(movement);
        }
    }
}
