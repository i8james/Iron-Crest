using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwapper : MonoBehaviour
{
public List<Camera> Cameras;

    void Start()
    {
        EnableCamera(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            EnableCamera(0);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            EnableCamera(1);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            EnableCamera(2);
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            EnableCamera(3);
        }

        /*
         * If you want to add more cameras, you need to add
         * some more 'else if' conditions just like above
         */
    }

    private void EnableCamera(int n)
    {
        Cameras.ForEach(cam => cam.enabled = false);
        Cameras[n].enabled = true;
    }
}