using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStatusPopup : MonoBehaviour
{
    public GameObject popup;

    // Start is called before the first frame update
    void Start()
    {
        popup.SetActive(false);
        EventManager.SendPopUpStatus += UnitStatusDisplay;
    }

    private void UnitStatusDisplay(int newDisplayState, Unit newDisplayUnit) {
        switch(newDisplayState) {
            case 0:
                popup.SetActive(true);
                break;
            case 1:
                popup.SetActive(false);
                break;

                
        }
    }

    
}
