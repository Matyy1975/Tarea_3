using UnityEngine;

public class ReflectAttack : MonoBehaviour
{
    public GameObject reflectObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == reflectObject)
        {
            // Objetos Reflect colisionados, activar evento de colisión del enemigo
            collision.GetComponent<Reflect>().ActivateCollisionEvent();
        }
    }
}

public class Reflect : MonoBehaviour    
{
    public GameObject enemyObject;

    private bool hasCollided = false;

    public void ActivateCollisionEvent()
    {
        hasCollided = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasCollided && collision.gameObject == enemyObject)
        {
            // El objeto Reflect ha colisionado con el enemigo, destruir el enemigo
            Destroy(enemyObject);
        }
    }
}
