using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuButtons : MonoBehaviour
{
    public GameObject pauseMenu;

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Restaura la escala de tiempo normal
        pauseMenu.SetActive(false); // Oculta el menú de pausa
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Carga de nuevo la escena actual
        Time.timeScale = 1f; // Restaura la escala de tiempo normal
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}




