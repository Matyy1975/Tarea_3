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
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("izq", true);
        }
        else
        {
            animator.SetBool("izq", false);
        }

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
