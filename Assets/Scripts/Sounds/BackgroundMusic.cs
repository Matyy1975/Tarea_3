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
        // Puedes pausar o detener la música en escenas específicas si lo deseas
        if (scene.name == "NombreDeLaEscenaDondeQuieresDetenerLaMusica")
        {
            // Pausar o detener la música
            GetComponent<AudioSource>().Pause(); // o Stop()
        }
        else
        {
            // Resumir o reproducir la música
            GetComponent<AudioSource>().Play(); // o UnPause()
        }
    }
}
