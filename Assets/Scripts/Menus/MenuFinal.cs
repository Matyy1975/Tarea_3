using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFinal : MonoBehaviour
{
    public GameObject menuUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Desactivar al jugador
            collision.gameObject.SetActive(false);

            // Activar el menú final
            menuUI.SetActive(true);

            // Si quieres pausar el juego completamente, puedes usar Time.timeScale
            // Time.timeScale = 0f;
        }
    }
}
