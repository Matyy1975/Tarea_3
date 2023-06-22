using UnityEngine;

public class HitCollision : MonoBehaviour
{
    public int damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        bool collisionWithReflect = false;
        int cc = collision.transform.childCount;
        for (int i = 0; i < cc; i++)
        {
            if(collision.transform.GetChild(i).name == "ReflectMelee" &&
                collision.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                collisionWithReflect = true;
            }
        }
        if (collisionWithReflect == false)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.TakeDamage(damage);
            }
        }
        else
        {
            EnemyHealth enemyHealth = this.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);
            }
            else
            {
                enemyHealth = this.transform.parent.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damage);
                }
            }
        }
    }
}
