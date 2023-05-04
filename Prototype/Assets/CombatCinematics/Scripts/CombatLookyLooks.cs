using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CombatLookyLooks : MonoBehaviour
{
    //Camera Methods added by James
    //I dont want to break the script so ill add it as extra functions
    public GameObject attackingUnit;
    public GameObject defendingUnit;
    public GameObject PerspectiveCam;
    public GameObject CombatCams;
    private GameObject Units;

    void Start()
    {
        GetAttacker();
        GetDefender();
        PerspectiveCam.gameObject.SetActive(true);
    }

    //Finds the attackers vcam
    public void GetAttacker()
    {
        attackingUnit = GameObject.Find("Capsule");
        //Transform childOfAnotherObject = attackingUnit.Find("attackingVCam");
        if (attackingUnit != null)
        {
            Debug.Log("Attacking Unit found");
        }
        else
        {
            Debug.Log("Attacking Unit Not Located");
        }
    }

    //Find the defenders vcam
    public void GetDefender()
    {
        defendingUnit = GameObject.Find("/Units/Cylinder");
        //Transform childOfAnotherObject = defendingUnit.Find("defendingVCam");
        if(defendingUnit != null)
        {
            Debug.Log("Defending Unit Found");
        }
        else
        {
            Debug.Log("Defending Unit Not Located");
        }
    }

    public void SwitchToMovingCam()
    {
        PerspectiveCam.gameObject.SetActive(true);
    }
    
    public void InitiateCombatCinematic()
    {
        PerspectiveCam.gameObject.SetActive(false);
        //Combat Cams Initiates the combat blend
        CombatCams.gameObject.SetActive(true);
        Debug.Log("Combat Finished...");
    }
}
