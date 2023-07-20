using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayButtonSound()
    {
        audioSource.Play();
    }
}
