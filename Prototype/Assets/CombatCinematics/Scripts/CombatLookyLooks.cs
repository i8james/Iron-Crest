using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CombatLookyLooks : MonoBehaviour
{
    //Camera Methods added by James
    //I dont want to break the script so ill add it as extra functions
    private GameObject attackingUnit;
    private GameObject defendingUnit;
    private GameObject attackingVCam;
    private GameObject defendingVCam;
    public GameObject CombatCam;
    void Start()
    {
        GetTheCameras();
        CombatCam.gameObject.SetActive(true);
        attackingVCam.gameObject.SetActive(false);
        defendingVCam.gameObject.SetActive(false);
    }

    //Gets the cameras of the attacking and defending unit
    public void GetTheCameras()
    {
        GetAttackerCam();
        GetDefenderCam();
    }

    //Finds the attackers vcam
    public void GetAttackerCam()
    {
        attackingUnit = GameObject.Find("/Units/Capsule");
        attackingVCam = GameObject.Find("attackingUnit/attackingVCam");
        //Transform childOfAnotherObject = attackingUnit.Find("attackingVCam");
        if (attackingUnit != null)
        {
            Debug.Log("Attacking Unit Not found");
        }
        else
        {
            if (attackingVCam != null)
            {
                Debug.Log("Attacking Camera not found an error has occured");
            }
            else
            {
                Debug.Log("Attacking Camera Found");
            }
        }
    }

    //Find the defenders vcam
    public void GetDefenderCam()
    {
        defendingUnit = GameObject.Find("/Units/Cylinder");
        defendingVCam = GameObject.Find("defendingUnit/defendingVCam");
        //Transform childOfAnotherObject = defendingUnit.Find("defendingVCam");
        if(defendingUnit != null)
        {
            Debug.Log("Defending Unit Not Found");
        }
        else
        {
            if (defendingVCam != null)
            {
                Debug.Log("Defending Camera not found an error has occured");
            }
            else
            {
                Debug.Log("Defending Camera Found");
            }
        }
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
    
    public void InitiateCombatCinematic()
    {
        SwapToAttackingCamera();
        SwapToDefendingCamera();
        CombatCam.gameObject.SetActive(true);
        Debug.Log("Combat Finished...");
    }
}
