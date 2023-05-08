using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartButton : MonoBehaviour
{
    public PartSelectButton owner;

    public GameObject heldPart;

    public int partType;

    public int handSide;

    public bool weaponButton;

    public bool unitSelect;

    public Unit heldUnit;

    public void Clicked()
    {
        if (unitSelect)
        {
            print(heldUnit.name);
            for(int i = 0; i < owner.AllPlayerUnits.Count; i++)
            {
                if(heldUnit == owner.AllPlayerUnits[i])
                {
                    owner.ChangeActiveUnit(i);
                }
            }
  
        } else
        if (heldPart)
        {
            if (weaponButton)
            {
                print(heldPart.name);
                owner.displayedPart = heldPart;
                owner.ChangePart(heldPart, handSide);
            }
            else
            {
                print(heldPart.name);
                owner.displayedPart = heldPart;
                owner.ChangePart(heldPart);
            }
        }
    }

    public void Hover()
    {
        if(heldPart)
        {
            if (weaponButton)
            {
                print(heldPart.name);
                owner.displayedPart = heldPart;
                owner.ChangeGridPart(heldPart, handSide);
            }
            else
            {
                print(heldPart.name);
                owner.displayedPart = heldPart;
                owner.ChangeGridPart(heldPart);
            }
        }
    }





}
