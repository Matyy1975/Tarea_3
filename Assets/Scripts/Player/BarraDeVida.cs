using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    public Image BarradeVida;
    public float VidaActual;
    public float VidaMaxima;

    // Update is called once per frame
    void Update()
    {
        BarradeVida.fillAmount = VidaActual / VidaMaxima;
    }
}
