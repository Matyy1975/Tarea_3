using UnityEngine;

public class BlockPlayer : MonoBehaviour
{
    public GameObject objectToActivate;
    public float activationDuration = 2f;

    private bool isActivated = false;
    private Quaternion originalRotation;

    private void Start()
    {
        originalRotation = objectToActivate.transform.rotation;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!isActivated)
            {
                Activate();
            }
        }
    }

    private void Activate()
    {
        isActivated = true;
        objectToActivate.SetActive(true);

        // Guardar la rotaci�n original del objeto
        originalRotation = objectToActivate.transform.rotation;

        // Detener la rotaci�n del objeto
        objectToActivate.transform.rotation = Quaternion.identity;

        Invoke("Deactivate", activationDuration);
    }

    private void Deactivate()
    {
        isActivated = false;

        // Restaurar la rotaci�n original del objeto
        objectToActivate.transform.rotation = originalRotation;

        objectToActivate.SetActive(false);
    }
}
