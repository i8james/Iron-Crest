using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechBuiler : MonoBehaviour
{
    public MenuButtons buttonMaster;

    public GameObject armPoint;

    public GameObject currentLegs;

    public GameObject currentBody;

    public GameObject currentArm;

    public GameObject spawnPoint;


    // Start is called before the first frame update
    void Start()
    {
        buttonMaster.previewMech = this;
        //InitialGear();
        StartCoroutine(Gear());
    }












    // Update is called once per frame
    void Update()
    {
        if(currentBody == null || currentArm == null || currentLegs == null)
        {
            //InitialGear();
        }
    }

    public void ChangeArms(GameObject newArms)
    {
        if (currentArm)
        {
            Destroy(currentArm);
        }
        var activePart = Instantiate(newArms, GetPart(currentBody, "ArmPoint").transform);
        //activePart.GetComponentsInChildren<GameObject>(). = gameObject.layer;
        foreach (Transform child in activePart.transform)
        {
            child.gameObject.layer = gameObject.layer;
            foreach (Transform child2 in child.transform)
            {
                child2.gameObject.layer = gameObject.layer;
            }
        }
        //activePart.transform.localPosition = partHolder.transform.localPosition;
        //activePart.transform.parent = partHolder.transform;
        activePart.transform.localPosition = Vector3.zero;



        //activePart.transform.localScale = Vector3.one * 70;
        activePart.SetActive(true);
        currentArm = activePart;
    }

    public void ChangeBody(GameObject newArms)
    {
        if (currentBody)
        {
            Destroy(currentBody);
        }
        var activePart = Instantiate(newArms, GetPart(currentLegs, "BodyPoint").transform);
        //activePart.GetComponentsInChildren<GameObject>(). = gameObject.layer;
        foreach (Transform child in activePart.transform)
        {
            child.gameObject.layer = gameObject.layer;
            foreach (Transform child2 in child.transform)
            {
                child2.gameObject.layer = gameObject.layer;
            }
        }
        //activePart.transform.localPosition = partHolder.transform.localPosition;
        //activePart.transform.parent = partHolder.transform;
        activePart.transform.localPosition = Vector3.zero;



        //activePart.transform.localScale = Vector3.one * 70;
        activePart.SetActive(true);
        currentBody = activePart;
    }

    public void ChangeLegs(GameObject newArms)
    {
        if (currentLegs)
        {
            Destroy(currentLegs);
        }
        var activePart = Instantiate(newArms, spawnPoint.transform);
        //activePart.GetComponentsInChildren<GameObject>(). = gameObject.layer;
        foreach (Transform child in activePart.transform)
        {
            child.gameObject.layer = gameObject.layer;
            foreach (Transform child2 in child.transform)
            {
                child2.gameObject.layer = gameObject.layer;
            }
        }
        //activePart.transform.localPosition = partHolder.transform.localPosition;
        //activePart.transform.parent = partHolder.transform;
        activePart.transform.localPosition = Vector3.zero;



        //activePart.transform.localScale = Vector3.one * 70;
        activePart.SetActive(true);
        currentLegs = activePart;
    }

    public void InitialGear()
    {
        currentLegs = Instantiate(buttonMaster.parts[2], spawnPoint.transform);
        currentLegs.transform.localPosition = Vector3.zero;

        currentBody = Instantiate(buttonMaster.parts[0], GetPart(currentLegs, "BodyPoint").transform);
        currentBody.transform.localPosition = Vector3.zero;
    
         
        currentArm = Instantiate(buttonMaster.parts[1], GetPart(currentBody, "ArmPoint").transform);
        currentArm.transform.localPosition = Vector3.zero;
        
    }

    IEnumerator Gear()
    {
        currentLegs = Instantiate(buttonMaster.parts[2], spawnPoint.transform);
        currentLegs.transform.localPosition = Vector3.zero;
        yield return null;

        currentBody = Instantiate(buttonMaster.parts[0], spawnPoint.transform); //GetPart(currentLegs, "BodyPoint").transform);
        currentBody.transform.localPosition = Vector3.zero;
        yield return null;


        currentArm = Instantiate(buttonMaster.parts[1], GetPart(currentBody, "ArmPoint").transform);
        currentArm.transform.localPosition = Vector3.zero;
        yield return null;
    }


    public GameObject GetPart(GameObject legs, string name)
    {
        foreach(GameObject child in legs.transform)
        {
            if (child.name == name)
            {
                return child;
            }
            foreach (GameObject child2 in child.transform)
            {
                if (child2.name == name)
                {
                    return child;
                }

            }
        }
        return null;
    }
}
