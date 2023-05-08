using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartPreviewUnit : MonoBehaviour
{
    public List<GameObject> parts = new List<GameObject>();

    public GameObject legs;

    public GameObject body;

    public GameObject rArm;

    public GameObject lArm;

    public GameObject lWeapon;

    public GameObject rWeapon;

    


    public bool displayMech;

    public MenuButtons menu;

    public GameObject partPosBase;

    public Material CustomMaterial;

    public List<GameObject> p2 = new List<GameObject>();

    private Transform previewPos;

    private GameObject partPos2;

    public List<GameObject> partPreviewParts;

    private bool gridView;


    public void InitialPartsSetup(List<GameObject> p, Transform previewPos)
    {
        StartCoroutine(placeParts(p, previewPos));
    }



    public void ReplaceGridParts()
    {
        for (int i = 0; i < p2.Count; i++)
        {
            //if(p2[i] != partPreviewParts[i])
            if (!p2[i].GetComponent<BasePart>().gridPrePart)
            {
                if (i == 4)
                {
                    ReplacePart(partPreviewParts[i], 1, null);
                }
                else if (i == 5)
                {
                    ReplacePart(partPreviewParts[i], 2, null);
                }
                else
                {
                    ReplacePart(partPreviewParts[i], 0, null);
                }
            }
        }
    }


    public void ReplacePart(GameObject newPart, int handSide, Unit newOwner)
    {
        if (newPart)
        {
            
            for (int i = 0; i < p2.Count; i++)
            {
               /* if (newPart.GetComponent<BasePart>().type == 4 )
                {

                } else */
                    if (newPart.GetComponent<BasePart>().type == p2[i].GetComponent<BasePart>().type)
                {
                    GameObject replace = Instantiate(newPart, previewPos);

                    
                    replace.transform.rotation = p2[i].transform.rotation;

                    if (newOwner != null)
                    {
                        newOwner.parts[i] = newPart;
                    }


                    if (i == 0)
                    {

                        replace.transform.parent = this.transform;
                        replace.transform.localPosition = Vector3.zero;

                        partPos2.transform.parent = replace.GetComponent<Legs>().bodyPoint.transform;
                        partPos2.transform.localPosition = Vector3.zero;
                        
                        Destroy(p2[i]);
                        p2[i] = replace;
                    

                    } else if (i == 4 || i == 5)
                    {
                        switch(handSide)
                        {
                            case 1:
                                if (i == 4)
                                {
                                    replace.transform.parent = p2[2].gameObject.GetComponent<Arms>().weaponPoint;
                                    replace.transform.localPosition = Vector3.zero;
                                    replace.transform.localScale = Vector3.one;
                                    //replace.transform.localRotation = Quaternion.
                                    Destroy(p2[i]);
                                    p2[i] = replace;

                           
                                }
                                break;
                            case 2:
                                if (i == 5)
                                {
                                    replace.transform.parent = p2[3].gameObject.GetComponent<Arms>().weaponPoint;
                                    replace.transform.localPosition = Vector3.zero;
                                    replace.transform.localScale = Vector3.one;
                                    //replace.transform.localRotation = Quaternion.
                                    Destroy(p2[i]);
                                    p2[i] = replace;
                                }
                                break;
                        }
                    } else if( i == 2)
                    {
                        p2[4].gameObject.transform.parent = replace.GetComponent<Arms>().weaponPoint;
                        p2[4].gameObject.transform.localScale = Vector3.one;
                        p2[4].gameObject.transform.rotation = replace.GetComponent<Arms>().weaponPoint.rotation;
                        replace.transform.position = p2[i].transform.position;

                        replace.transform.parent = partPos2.transform;
                        Destroy(p2[i]);
                        p2[i] = replace;


                    } else if (i == 3)
                    {
                        p2[5].gameObject.transform.parent = replace.GetComponent<Arms>().weaponPoint;
                        p2[5].gameObject.transform.localScale = Vector3.one;
                        p2[5].gameObject.transform.rotation = replace.GetComponent<Arms>().weaponPoint.rotation;
                        replace.transform.position = p2[i].transform.position;
                        replace.transform.parent = partPos2.transform;
                        Destroy(p2[i]);
                        p2[i] = replace;
                    } else
                    {
                        replace.transform.position = p2[i].transform.position;
                        Destroy(p2[i]);
                        replace.transform.parent = partPos2.transform;
                        p2[i] = replace;
                    }
                  
                }
            }
        }
    }




    IEnumerator placeParts(List<GameObject> p, Transform previewPos)
    {

        
        for(int i = 0; i < p.Count; i++)
        {
            p2.Add(null);
        }

        
        GameObject newPart = null;


        Destroy(p2[0]);
        // Destroy(legs);
        newPart = Instantiate(p[0], this.gameObject.transform);
        newPart.transform.localPosition = Vector3.zero;
        newPart.transform.parent = previewPos.gameObject.transform;
        p2[0] = newPart;
        //UILayer(legs);

        yield return null;

        GameObject partPos = Instantiate(partPosBase, p2[0].GetComponent<Legs>().bodyPoint.transform);

        partPos.transform.localPosition = Vector3.zero;
        partPos.transform.parent = this.gameObject.transform;
        
        p2[0].transform.parent = partPos.transform;
        PartPosHolder holderScript = partPos.GetComponent<PartPosHolder>();


        yield return null;


        Destroy(p2[1]);
        //Destroy(body);
        newPart = Instantiate(p[1], holderScript.torsoPoint);
        newPart.transform.localPosition = Vector3.zero;
        //newPart.transform.parent = ownerUnit.gameObject.transform;
        p2[1] = newPart;

        //UILayer(body);

        yield return null;
        Destroy(p2[2]);
        newPart = Instantiate(p[2], holderScript.RArmPoint);
        newPart.transform.localPosition = Vector3.zero;
        //newPart.transform.parent = ownerUnit.gameObject.transform;
        p2[2] = newPart;
        //UILayer(arms);
        yield return null;


        Destroy(p2[3]);
        newPart = Instantiate(p[3], holderScript.LArmPoint);
        newPart.transform.localPosition = Vector3.zero;
        //newPart.transform.parent = ownerUnit.gameObject.transform;
        p2[3] = newPart;
        //UILayer(arms);
        yield return null;

        Destroy(p2[4]);
        newPart = Instantiate(p[4], p2[2].GetComponent<Arms>().weaponPoint);
        newPart.transform.localPosition = Vector3.zero;
        p2[4] = newPart;
        yield return null;

        Destroy(p2[5]);
        newPart = Instantiate(p[5], p2[3].GetComponent<Arms>().weaponPoint);
        newPart.transform.localPosition = Vector3.zero;
        p2[5] = newPart;
        yield return null;

        partPos2 = partPos;

    }
    
}
