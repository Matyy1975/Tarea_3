using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float destroyDelay = 5f; // Tiempo en segundos antes de autodestruirse

    private void Start()
    {
        Destroy(gameObject, destroyDelay); // Destruir el objeto despu�s de destroyDelay segundos
    }
}
