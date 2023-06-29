using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public float mouseSensitivity = 2f;
    public Vector3 offset = new Vector3(0f, 0f, -10f);
    public float zoomSpeed = 2f;
    public float minZoomDistance = 5f;
    public float maxZoomDistance = 15f;

    private Vector3 desiredPosition;
    private float currentZoom = 0f;

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position;
            float scrollInput = Input.GetAxis("Mouse ScrollWheel");
            currentZoom -= scrollInput * zoomSpeed;
            currentZoom = Mathf.Clamp(currentZoom, minZoomDistance, maxZoomDistance);
            Vector3 zoomOffset = offset.normalized * currentZoom;
            Vector3 mouseOffset = new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"), 0f) * mouseSensitivity;
            desiredPosition = targetPosition + zoomOffset + mouseOffset;
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        if (target != null)
        {
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.fixedDeltaTime);
        }
    }
}
