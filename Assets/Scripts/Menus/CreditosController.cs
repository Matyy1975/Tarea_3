using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditosController : MonoBehaviour
{
    public float tiempoDeEspera = 5f; // Tiempo que los cr�ditos se mostrar�n antes de volver al men� principal

    void Start()
    {
        Invoke("CargarMenuPrincipal", tiempoDeEspera);
    }

    void CargarMenuPrincipal()
    {
        SceneManager.LoadScene("MenuPrincipal"); // Cambia "MenuPrincipal" por el nombre de tu escena principal
    }
}

