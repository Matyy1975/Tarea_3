using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private Animator animator; // Referencia al componente Animator
    private bool isTransitioning = false; // Indica si se está reproduciendo una transición

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public string CambioEscena; // Nombre de la escena a la que se cambiará

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isTransitioning)
        {
            isTransitioning = true; // Marcar que se está reproduciendo una transición

            // Reproducir la animación de transición
            animator.SetTrigger("Transition");

            // Esperar la duración de la animación de transición antes de cambiar la escena
            float transitionDuration = animator.GetCurrentAnimatorStateInfo(0).length;
            StartCoroutine(ChangeSceneAfterDelay(transitionDuration));
        }
    }

    private IEnumerator ChangeSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Cambiar a la escena especificada
        SceneManager.LoadScene(CambioEscena);
    }

}
