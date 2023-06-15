using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenu;
    private bool isPaused = false;

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // Pausa el tiempo en el juego
            pauseMenu.SetActive(true); // Activa el menú de pausa
        }
        else
        {
            Time.timeScale = 1f; // Restaura la escala de tiempo normal
            pauseMenu.SetActive(false); // Desactiva el menú de pausa
        }
    }
}


