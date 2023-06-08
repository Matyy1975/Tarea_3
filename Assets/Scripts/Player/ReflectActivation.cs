using UnityEngine;
using System.Collections;

public class ReflectActivation : MonoBehaviour
{
    public GameObject objectToActivate;
    public float activationTime = 2f;

    private bool isActivated = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isActivated)
        {
            StartCoroutine(ActivateObject());
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
}
