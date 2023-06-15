using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject player;
    public GameObject hitObject;
    public float attackRange = 3f;

    private bool isPlayerInRange;

    private void Update()
    {
        if (player == null)
        {
            Debug.LogError("Player object not found!");
            return;
        }

        // Calcula la distancia entre el enemigo y el jugador
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= attackRange)
        {
            // El jugador está dentro del rango de ataque
            isPlayerInRange = true;
            hitObject.SetActive(true);
        }
        else
        {
            // El jugador está fuera del rango de ataque
            isPlayerInRange = false;
            hitObject.SetActive(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Dibuja una esfera gizmo para representar el rango de ataque del enemigo
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
