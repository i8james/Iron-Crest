using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class FlexibleCameraSwitch : MonoBehaviour
{
    //Old Camera Swapper list
    public CinemachineVirtualCamera[] cameraList;
    private int currentCamera;
    public GameObject PerspectiveCamera;

    // Start is called before the first frame update
    void Start()
    {
        currentCamera = 0;
        for (int i = 0; i < cameraList.Length; i++)
        {
            cameraList[i].gameObject.SetActive(false);
        }

        if (cameraList.Length > 0)
        {
            cameraList[0].gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            //SwapCamera();
        }
    }

    public void SwitchToCombatCamera()
    {
        cameraList[currentCamera].gameObject.SetActive(false);
        PerspectiveCamera.gameObject.SetActive(true);
    }

    public void SwapCamera()
    {
        PerspectiveCamera.gameObject.SetActive(false);
        currentCamera++;
        if (currentCamera < cameraList.Length)
        {
            cameraList[currentCamera - 1].gameObject.SetActive(false);
            cameraList[currentCamera].gameObject.SetActive(true);
        }
        else
        {
            cameraList[currentCamera - 1].gameObject.SetActive(false);
            currentCamera = 0;
            cameraList[currentCamera].gameObject.SetActive(true);
        }
    }
}
