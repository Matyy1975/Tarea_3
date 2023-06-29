using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 newCamPos, newPlayerPos;

    CamController camControl;
    void Start()
    {
        camControl = Camera.main.GetComponent<CamController>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            camControl.minPos += newCamPos;
            camControl.maxPos += newCamPos;

            other.transform.position += newPlayerPos;
        }
    }
}
