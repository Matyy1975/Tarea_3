using UnityEngine;
using UnityEngine.Events;

public class ObjectActivator : MonoBehaviour
{
    public bool detectOnPlayerEnter = true;
    public UnityEvent onPlayerEnter;
    public GameObject[] objectsToActivate; // Array de objetos a activar

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (detectOnPlayerEnter) {
                onPlayerEnter.Invoke();
            }
            // Activar los objetos en la escena
            foreach (GameObject objectToActivate in objectsToActivate)
            {
                objectToActivate.SetActive(true);
            }

            // Destruir este objeto activador
            Destroy(gameObject);
        }
    }

    public void DisableOnEnter()
    {
        detectOnPlayerEnter = false;
    }
}
