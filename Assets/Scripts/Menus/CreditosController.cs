using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditosController : MonoBehaviour
{
    public float tiempoDeEspera = 5f; // Tiempo que los créditos se mostrarán antes de volver al menú principal

    void Start()
    {
        Invoke("CargarMenuPrincipal", tiempoDeEspera);
    }

    void CargarMenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal"); // Cambia "MenuPrincipal" por el nombre de tu escena principal
    }
}

