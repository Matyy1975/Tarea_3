using UnityEngine;

public class MouseAim : MonoBehaviour
{
    public Transform rotationPoint;

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector3 direction = mousePosition - rotationPoint.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rotationPoint.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
