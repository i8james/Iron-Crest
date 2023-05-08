using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartSelectMenuBase : MonoBehaviour
{
    Unit displayedUnit;

    List<Pilot> pilotPortraits;

    string queuedMission;

    GameObject partHolder;

    GameObject pilotHolder;

    private void RecieveChangeDisplayedPilot(Pilot newActivePilot)
    {
        DestroyDisplayedUnit();
        InstantiateDisplayedUnit(newActivePilot.equippedUnit);
        displayedUnit = newActivePilot.equippedUnit;
        PartSelectGameManager.PSInstance.activeDisplayUnit = newActivePilot.equippedUnit;
        //Change displayed unit
        //Give unit an idle animation
        //Change stats
    }

    private void RecieveSelectedPart()
    {
        //Open part select menu
    }

    private void RecieveEnterMissionRequest()
    {
        //Change scene to mission
    }

    private void InstantiateDisplayedUnit(Unit newDisplayedUnit)
    {
       // GameObject newUnit = Instantiate(newDisplayedUnit, pilotHolder.transform);

    }

    private void DestroyDisplayedUnit()
    {
        Destroy(displayedUnit.gameObject);
    }



    



}


