using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PartSelectButton : MonoBehaviour
  
{

    //public List<Button> catagoryButtons;

    public GameObject buttonPrefab;


    public List<GameObject> displayedParts;

    public GameObject displayHolder;

    public GameObject displayHolderPrefab;

    public Transform displayHolderPos;

    public GameObject displayedPart;

    public List<GameObject> defaultParts;

    public List<List<GameObject>> units = new List<List<GameObject>>();

    public PartPreviewUnit fullUnitPre;

    public PartPreviewUnit partGridPre;

    public Unit activeUnit;

    public List<Unit> AllPlayerUnits = new List<Unit>();

    public GameObject GMUnitHolder;

    public int numUnits;

    public GameObject unitPrefab;

    public GameObject unitIconDisplayHolder;

    public Transform unitIconDisplayHolderPos;


    // Start is called before the first frame update
    void Start()
    {
        BuildNewUnitList();
        

        ChangeActiveUnit(0);
    }

    private void Awake()
    {
        for (int i = 0; i < numUnits; i++)
        {


            //activeUnit.parts = defaultParts;
            //activeUnit = AllPlayerUnits[0];


            GameObject newUnitHolder = Instantiate(new GameObject(), GMUnitHolder.transform);
            newUnitHolder.name = "Player Unit " + i;
            Unit newUnit = newUnitHolder.AddComponent<Unit>();
            //newUnit.name = "Player Unit " + i;
            newUnit.parts = defaultParts;
            AllPlayerUnits.Add(newUnit);



        }
    }

    public void BuildNewUnitList()
    {
        Destroy(unitIconDisplayHolder);

        GameObject buttonParent = Instantiate(displayHolderPrefab, unitIconDisplayHolderPos);



        for (int i = 0; i < AllPlayerUnits.Count; i++)
        {
            GameObject newButton = Instantiate(buttonPrefab, buttonParent.transform);
            newButton.GetComponentInChildren<TextMeshProUGUI>().text = "Unit " + i;
            PartButton newPB = newButton.GetComponent<PartButton>();
            newPB.owner = this;
            newPB.heldUnit = AllPlayerUnits[i];
            newPB.unitSelect = true;
           
        }

        unitIconDisplayHolder = buttonParent;

    }


    public void ChangeActiveUnit(int selection)
    {
        Destroy(displayHolder);

        displayedParts.Clear();

        partGridPre.ReplaceGridParts();

        activeUnit = AllPlayerUnits[selection];
   
        SetUpUnitDisplay();
    }




    public void SwitchCatagory(int newType)
    {
           if (displayHolder)
           {
               Destroy(displayHolder);
           }


        displayedParts.Clear();

        partGridPre.ReplaceGridParts();

        int handSide = 0;

       
        

        List<GameObject> stockParts = GameManager.Instance.stockParts;
        for(int i = 0; i < GameManager.Instance.stockParts.Count; i++)
        {

            if(newType == 4 || newType == 5)
            {
                switch (newType)
                {
                    case 4:
                        handSide = 1;
                        break;
                    case 5:
                        handSide = 2;
                        break;
                }
                if (stockParts[i].GetComponent<BasePart>().type == 4)
                {
                    displayedParts.Add(stockParts[i]);
                }
            } else
            if(stockParts[i].GetComponent<BasePart>().type == newType)
            {
                displayedParts.Add(stockParts[i]);
            } 


        }

        BuildNewList(handSide);

    }

    public void ChangePlayerUnit(int selection)
    {
        activeUnit = AllPlayerUnits[selection];
    }

    public void BuildNewList(int handSide)
    {
        Destroy(displayHolder);

        GameObject buttonParent = Instantiate(displayHolderPrefab, displayHolderPos);
        


        for(int i = 0; i < displayedParts.Count; i++)
        {
            GameObject newButton = Instantiate(buttonPrefab, buttonParent.transform);
            newButton.GetComponentInChildren<TextMeshProUGUI>().text = displayedParts[i].name;
            PartButton newPB = newButton.GetComponent<PartButton>();//AddComponent<PartButton>();
            newPB.owner = this;
            newPB.heldPart = displayedParts[i];
            newPB.partType = displayedParts[i].GetComponent<BasePart>().type;   
            if(handSide != 0)
            {
                newPB.weaponButton = true;
                newPB.handSide = handSide;
            }
        }



        displayHolder = buttonParent;
    }

    
    public void SetUpUnitDisplay()
    {
        partGridPre.InitialPartsSetup(partGridPre.partPreviewParts, partGridPre.gameObject.transform);
        fullUnitPre.InitialPartsSetup(activeUnit.parts, fullUnitPre.gameObject.transform);
    }


    public void ChangePart(GameObject newPart)
    {

        partGridPre.ReplacePart(newPart, 0, null);
        fullUnitPre.ReplacePart(newPart, 0, activeUnit);
    }

    public void ChangeGridPart(GameObject newPart)
    {
        partGridPre.ReplacePart(newPart, 0, null);
    }

    public void ChangeGridPart(GameObject newPart, int handSide)
    {
        partGridPre.ReplacePart(newPart, handSide, null);
     
    }

    public void ChangePart(GameObject newPart, int handSide)
    {
        partGridPre.ReplacePart(newPart, handSide, null);
        fullUnitPre.ReplacePart(newPart, handSide, activeUnit);
    }



}
