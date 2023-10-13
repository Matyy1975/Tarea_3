using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    // para hacer funcionar este script, en la camara coloca un cinemachineBrain
    /// <summary>
    /// en el update method tienes que tener un fixedupdate
    /// en blend update method tienes que tener un fixed update
    /// luego te creas un objeto que se llame "CameraPos" en el que asignaremos este script
    /// en el cam agregas la camara que tengas en la escena que usaras,
    /// en el transform "player" agregas al objeto que sea el player en esa escena
    /// y finalmente para que funcione en el cinemachine que es el  CM vcam1, hay una parte
    /// que dice follow en el que asignaremos al objeto en este caso sera el "CameraPos"
    /// </summary>
    [SerializeField] Camera cam;
    [SerializeField] Transform player;
    [SerializeField] float threshold;
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPos = (player.position + mousePos) / 2f;

        targetPos.x = Mathf.Clamp(targetPos.x, -threshold + player.position.x, threshold + player.position.x);
        targetPos.y = Mathf.Clamp(targetPos.y, -threshold + player.position.y, threshold + player.position.y);

        this.transform.position = targetPos;
    }
}
