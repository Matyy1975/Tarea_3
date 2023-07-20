using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundMusic : MonoBehaviour
{
    private static BackgroundMusic instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Puedes pausar o detener la m�sica en escenas espec�ficas si lo deseas
        if (scene.name == "NombreDeLaEscenaDondeQuieresDetenerLaMusica")
        {
            // Pausar o detener la m�sica
            GetComponent<AudioSource>().Pause(); // o Stop()
        }
        else
        {
            // Resumir o reproducir la m�sica
            GetComponent<AudioSource>().Play(); // o UnPause()
        }
    }
}
