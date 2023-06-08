using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Referencia al transform del jugador
    public float smoothSpeed = 0.125f; // Velocidad de suavizado del seguimiento
    public Vector3 offset; // Desplazamiento relativo entre la c�mara y el jugador

    private void LateUpdate()
    {
        // Calcula la posici�n objetivo de la c�mara sumando el desplazamiento al jugador
        Vector3 targetPosition = target.position + offset;

        // Interpola suavemente la posici�n actual de la c�mara hacia la posici�n objetivo
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, targetPosition, smoothSpeed);

        // Establece la posici�n de la c�mara
        transform.position = smoothedPosition;
    }
}
