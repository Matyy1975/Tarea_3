using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioClip soundClip;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Se verifica el clic izquierdo del mouse
        {
            PlaySound();
        }
    }

    private void PlaySound()
    {
        audioSource.PlayOneShot(soundClip);
    }
}
