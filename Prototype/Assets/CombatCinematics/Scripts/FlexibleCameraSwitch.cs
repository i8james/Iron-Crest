using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlexibleCameraSwitch : MonoBehaviour
{
    //Old Camera Swapper list
    public GameObject[] cameraList;
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
    //Recycled combat cinematics

    /*//Below is what you can use with the cameras are the units VCams.
    public void AttackingCinematic()
    {
        PerspectiveCamera.gameObject.SetActive(false);
        AttackerCamera.gameObject.SetActive(true);
    }
    public void DefendingCinematic()
    {
        AttackerCamera.gameObject.SetActive(false);
        DefendingCamera.gameObject.SetActive(true);
    }*/


    //Camera Methods added by James
    //I dont want to break the script so ill add it as extra functions
    private GameObject CombatCamera;
    public Transform attackingUnit;
    public Transform defendingUnit;
    public GameObject Attacker;
    public GameObject Defender;
    private GameObject attackingVCam;
    private GameObject defendingVCam;
    private bool AttackingCamReady;
    private bool DefendingCamReady;

    //Gets the cameras of the attacking and defending unit
    public void GetTheCameras()
    {
        GetAttackerCam();
        GetDefenderCam();
        CombatCamera = PerspectiveCamera;
        if (AttackingCamReady == true)
        {
            if (DefendingCamReady == true)
            {
                InitiateCombatCinematic();
            }
        }
    }
    
    //Finds the attackers vcam
    public void GetAttackerCam()
    {
        Transform childOfAnotherObject = attackingUnit.Find("attackingVCam");
        Debug.Log("Attacking Camera Found");
        AttackingCamReady = true;
    }

    //Find the defenders vcam
    public void GetDefenderCam()
    {
        Transform childOfAnotherObject = defendingUnit.Find("defendingVCam");
        Debug.Log("Attacking Camera Found");
        DefendingCamReady = true;
    }
    public void InitiateCombatCinematic()
    {
        SwapToAttackingCamera();
        SwapToDefendingCamera();
        CombatCamera.gameObject.SetActive(true);
        Debug.Log("Combat Finished...");
    }
    //Swaps the active camera to the attackers camera
    public void SwapToAttackingCamera()
    {
        attackingVCam.gameObject.SetActive(true);
        //Attacking animations + Sounds trigger
        Debug.Log("Pew Pew!!");
    }
    //Swaps the active camera to defending camera
    public void SwapToDefendingCamera()
    {
        defendingVCam.gameObject.SetActive(true);
        Debug.Log("Ouch i got hit!!!");
    }
}
