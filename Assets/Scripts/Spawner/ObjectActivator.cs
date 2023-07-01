using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    public GameObject[] objectsToActivate; // Array de objetos a activar

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Activar los objetos en la escena
            foreach (GameObject objectToActivate in objectsToActivate)
            {
                objectToActivate.SetActive(true);
            }

            // Destruir este objeto activador
            Destroy(gameObject);
        }
    }
}
