using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camChangeTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera currentCamera;
    public bool isInCurrent = false;

    void Start()
    {
    }

    // Update is called once per frame
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && isInCurrent == false)
        {
            Camera[] cams = FindObjectsOfType<Camera>();
            for (int i = 0; i < cams.Length; i++)
            {
                if(cams[i].gameObject.tag == "MainCamera")
                {
                    cams[i].gameObject.SetActive(false);
                    cams[i].gameObject.tag = "SecundaryCamera";

                }
            }

            currentCamera.gameObject.SetActive(true);
            currentCamera.gameObject.tag = "MainCamera";
            isInCurrent = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isInCurrent = false;
    }
}
