using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuFinal : MonoBehaviour
{
    public GameObject menuUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            menuUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
