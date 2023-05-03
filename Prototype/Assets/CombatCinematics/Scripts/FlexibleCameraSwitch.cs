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
        //Should have the map camera be the one that the game starts with.
        //MapCamera.gameObject.SetActive(true);
    }

    public void SwitchToCombatCamera()
    {
        cameraList[0].gameObject.SetActive(true);
        Debug.Log("Swapped to Mobile camera");
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

    //Camera Methods added by James
    //I dont want to break the script so ill add it as extra functions
    [Header("Drag and Drop")]
    public CinemachineVirtualCamera attackingVCam;
    public CinemachineVirtualCamera defendingVCam;
    public int transitionTime = 2;

    IEnumerator Waiter()
    {
        yield return new WaitForSeconds(transitionTime);
    }

    public void InitiateCombatCinematic()
    {
        CombativeCameraSwap();
        PerspectiveCamera.gameObject.SetActive(true);
        Debug.Log("Combat Finished...");
    }
    public void CombativeCameraSwap()
    {
        cameraList[currentCamera].gameObject.SetActive(false);
        SwapToAttackingCamera();
        //StartCoroutine(Waiter());
        SwapToDefendingCamera();
    }
    //Swaps the active camera to the attackers camera
    public void SwapToAttackingCamera()
    {
        cameraList[currentCamera].gameObject.SetActive(false);
        attackingVCam.gameObject.SetActive(true);
        //Attacking animations + Sounds trigger
        Debug.Log("Pew Pew!!");
    }
    //Swaps the active camera to defending camera
    public void SwapToDefendingCamera()
    {
        cameraList[currentCamera].gameObject.SetActive(false);
        defendingVCam.gameObject.SetActive(true);
        //Stagger/death effects
        Debug.Log("Ouch i got hit!!!");
    }
}
