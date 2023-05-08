using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartBuildHelper : MonoBehaviour
{
    public int maxWeight;

    public PartBuilder builder;


    public Texture legRenderTarget;

    public Texture lArmRenderTarget;

    public Texture rArmRenderTarget;

    public Texture torsoRenderTarget;

    public Texture headRenderTarget;
    
    public PartClass currentDisplay;

    public List<GameObject> previewBaseParts;
    
    public int selectedCatagory;

    public List<GameObject> activePartCatagory;

    public List<List<GameObject>> partCatagories = new List<List<GameObject>>();

    public List<GameObject> bodies = new List<GameObject>();

    public List<GameObject> rArms = new List<GameObject>();

    public List<GameObject> lArms = new List<GameObject>();

    public List<GameObject> legs = new List<GameObject>();

    public List<GameObject> rWeapon = new List<GameObject>();

    public List<GameObject> lWeapon= new List<GameObject>();
    
    public Unit editTarget;

    public List<GameObject> catagoryTargetSprites = new List<GameObject>();
    public List<Sprite> partTargetSprites = new List<Sprite>();

    public void begin() {
        partCatagories.Add(legs);
        partCatagories.Add(bodies);
        partCatagories.Add(rArms);
        partCatagories.Add(lArms);
        partCatagories.Add(lWeapon);
        partCatagories.Add(rWeapon);
    }

    public void uDate() {
        List<GameObject> activePartCatagory = partCatagories[0];

        for (int i = 0; i < catagoryTargetSprites.Count; i++) 
        {
            //catagoryTargetSprites[i] = activePartCatagory[i].GetComponent<BasePart>().partIcon;
            

        }
    }

    


    public void CatagorySpin(int direction) {
        switch(direction) {
            case 1:

                List<GameObject> finalCatagory = partCatagories[partCatagories.Count - 1];

               

                for (int i = partCatagories.Count; i < 0; i--) {
                    partCatagories[i] = partCatagories[i-1]; 

                    if(i == 0) {
                        partCatagories[0] = finalCatagory;
                    }
                }

                break;

            case 2:

                List<GameObject> firstCatagory = partCatagories[0];

               

                for (int i = 0; i < partCatagories.Count; i++) {
                    partCatagories[i - 1] = partCatagories[i]; 

                    if(i == partCatagories.Count - 1) {
                        partCatagories[partCatagories.Count - 1] = firstCatagory;
                    }
                }
                
                break;
        }
    }

    public void PartSpin(int direction) {

        List<GameObject> partCatagory = partCatagories[0];
        
        switch(direction) {
            case 1:

                
                GameObject finalPart = partCatagory[partCatagory.Count - 1];


                for (int i = partCatagory.Count; i < 0; i--) {
                    partCatagory[i] = partCatagory[i-1]; 

                    if(i == 0) {
                        partCatagory[0] = finalPart;
                    } 
                }

                break;

            case 2:

                GameObject firstPart = partCatagory[0];

                for (int i = 0; i < partCatagory.Count; i++) {
                    partCatagory[i - 1] = partCatagory[i]; 

                    if(i == partCatagory.Count - 1) {
                        partCatagory[partCatagory.Count - 1] = firstPart;
                    }
                }
                
                break;
        }
    }




    
}

public enum PartClass {
    Legs,
    lArm,
    rArm,
    Torso,
    Head,

}