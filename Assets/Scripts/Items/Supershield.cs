using UnityEngine;

public class Supershield : MonoBehaviour
{
    public GameObject shieldObject; // Objeto del escudo
    public float shieldDuration = 5f; // Duraci�n del escudo en segundos

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Activar el escudo
            shieldObject.SetActive(true);

            // Desactivar el escudo despu�s de X segundos
            StartCoroutine(DeactivateShield());
        }
    }

    private System.Collections.IEnumerator DeactivateShield()
    {
        yield return new WaitForSeconds(shieldDuration);

        // Desactivar el escudo
        shieldObject.SetActive(false);
    }
}
