using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //ANIMACION JUGADOR HACIA ARRIBA
        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Arr", true);
        }
        else
        {
            animator.SetBool("Arr", false);
        }
        //ANIMACION JUGADOR HACIA ABAJO
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("Aba", true);
        }
        else
        {
            animator.SetBool("Aba", false);
        }
        //ANIMACION JUGADOR HACIA LA IZQUIERDA
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("izq", true);
        }
        else
        {
            animator.SetBool("izq", false);
        }
        //ANIMACION JUGADOR HACIA LA DERECHA
        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Der", true);
        }
        else
        {
            animator.SetBool("Der", false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("Atk", true);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("Atk", false);
        }
    }
}
