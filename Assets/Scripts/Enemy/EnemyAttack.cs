using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject player;
    public GameObject hitObject;
    public float attackRange = 3f;
    public float hitDelay = 2f;
    public float hitDuration = 1f;

    private float hitDelayTimer;
    private float hitDurationTimer;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().gameObject;
    }

    private void Update()
    {
        if (player == null)
        {
            Debug.LogError("Player object not found!");
            return;
        }

        // Calcula la distancia entre el enemigo y el jugador
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        Debug.Log(distanceToPlayer);

        if (distanceToPlayer <= attackRange)
        {

            if (hitDelayTimer < hitDelay)
            {
                // Espera el tiempo de demora antes de activar el objeto "hit"
                hitDelayTimer += Time.deltaTime;
            }
            else
            {
                // El tiempo de demora ha transcurrido, activa el objeto "hit" y cuenta la duración
                hitDurationTimer += Time.deltaTime;
                hitObject.SetActive(true);

                if (hitDurationTimer >= hitDuration)
                {
                    // El tiempo de duración ha transcurrido, desactiva el objeto "hit"
                    hitObject.SetActive(false);

                    // Reinicia los temporizadores
                    hitDelayTimer = 0f;
                    hitDurationTimer = 0f;
                }
            }
        }
        else
        {
            // El jugador está fuera del rango de ataque
            hitObject.SetActive(false);

            // Reinicia los temporizadores
            hitDelayTimer = 0f;
            hitDurationTimer = 0f;
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Dibuja una esfera gizmo para representar el rango de ataque del enemigo
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
