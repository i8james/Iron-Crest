using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CombatLookyLooks : MonoBehaviour
{
    //Camera Methods added by James
    //I dont want to break the script so ill add it as extra functions
    private GameObject attackingUnit;
    public Transform attackingUnitTransform;
    public CinemachineVirtualCamera attackingVcam;
    private GameObject defendingUnit;
    public Transform defendingUnitTransform;
    public CinemachineVirtualCamera defendingVcam;
    public GameObject PerspectiveCam;
    public GameObject CombatCams;
    private GameObject Units;

    void Start()
    {
        GetAttacker();
        GetDefender();
        PerspectiveCam.gameObject.SetActive(true);
    }

    //Finds the attacking unit
    public void GetAttacker()
    {
        attackingUnit = GameObject.Find("Capsule");
        //Replace the previous line with the attacking unit finding script call
        if (attackingUnit != null)
        {
            Debug.Log("Attacking Unit found");
            AttackingCamLooksAndFollows();
        }
        else
        {
            Debug.Log(attackingUnit +"Unit Not found");
        }
    }

    public void AttackingCamLooksAndFollows()
    {
        attackingUnitTransform = attackingUnit.GetComponent<Transform>();
        if (attackingUnitTransform != null)
        {
            Debug.Log(attackingUnit + "transform found");
            attackingVcam.LookAt = attackingUnitTransform;
            attackingVcam.Follow = attackingUnitTransform;
        }
        else
        {
            Debug.Log(attackingUnit + "units transform not found");
        }
    }

    //Find the defending unit
    public void GetDefender()
    {
        defendingUnit = GameObject.Find("/Units/Cylinder");
        //Transform childOfAnotherObject = defendingUnit.Find("defendingVCam");
        if(defendingUnit != null)
        {
            Debug.Log(defendingUnit + "Unit Found");
            DefenderCamLooksAndFollows();
        }
        else
        {
            Debug.Log("Defending Unit Not found");
        }
    }

    public void DefenderCamLooksAndFollows()
    {
        defendingUnitTransform = defendingUnit.GetComponent<Transform>();
        if (attackingUnitTransform != null)
        {
            Debug.Log(defendingUnit + "transform found");
            defendingVcam.LookAt = defendingUnitTransform;
            defendingVcam.Follow = defendingUnitTransform;
        }
        else
        {
            Debug.Log(defendingUnit + "transform not found");
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
