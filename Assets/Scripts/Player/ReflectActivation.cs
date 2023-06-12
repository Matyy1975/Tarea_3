using UnityEngine;
using System.Collections;

public class ReflectActivation : MonoBehaviour
{
    public GameObject objectToActivate;
    public GameObject alternativeObjectToActivate;
    public float activationTime = 2f;
    public float alternativeActivationTime = 2f;

    private bool isActivated = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isActivated)
        {
            StartCoroutine(ActivateObject());
        }

        if (Input.GetMouseButtonDown(1) && !isActivated)
        {
            StartCoroutine(ActivateAlternativeObject());
        }
    }

    private IEnumerator ActivateObject()
    {
        isActivated = true;
        objectToActivate.SetActive(true);

        yield return new WaitForSeconds(activationTime);

        objectToActivate.SetActive(false);
        isActivated = false;
    }

    private IEnumerator ActivateAlternativeObject()
    {
        isActivated = true;
        alternativeObjectToActivate.SetActive(true);

        yield return new WaitForSeconds(alternativeActivationTime);

        alternativeObjectToActivate.SetActive(false);
        isActivated = false;
    }
}
