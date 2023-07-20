using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactShield : MonoBehaviour
{
    public Animator animator; // Referencia al Animator que contiene la animación "impactShield"

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile")|| other.CompareTag("Projectile 2") || other.CompareTag("Projectile 3"))
        {
            // Reproducir la animación de impacto.
            animator.SetTrigger("Impact Shielder");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
