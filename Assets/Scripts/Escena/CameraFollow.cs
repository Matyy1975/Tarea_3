using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Referencia al transform del jugador
    public float smoothSpeed = 0.125f; // Velocidad de suavizado del seguimiento
    public Vector3 offset; // Desplazamiento relativo entre la cámara y el jugador

    private void LateUpdate()
    {
        // Calcula la posición objetivo de la cámara sumando el desplazamiento al jugador
        Vector3 targetPosition = target.position + offset;

        // Interpola suavemente la posición actual de la cámara hacia la posición objetivo
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);

        // Establece la posición de la cámara
        transform.position = smoothedPosition;
    }
}
