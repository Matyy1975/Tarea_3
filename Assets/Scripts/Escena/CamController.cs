using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public float smoothSpeed;

    private Vector3 targetPos, newpos;

    public Vector3 minPos, maxPos;



    // Update is called once per frame
    void LateUpdate()
    {
        if (transform.position != player.position)
        {
            targetPos = player.position;

            Vector3 camBoundaryPos = new Vector3(
                Mathf.Clamp(targetPos.x, minPos.x, maxPos.x),
                Mathf.Clamp(targetPos.y, minPos.y, maxPos.y),
                Mathf.Clamp(targetPos.z, minPos.z, maxPos.z));

            newpos = Vector3.Lerp(transform.position, camBoundaryPos, smoothSpeed);
            transform.position = newpos;
        }
    }
}
