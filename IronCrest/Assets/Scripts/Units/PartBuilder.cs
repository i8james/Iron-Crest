using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartBuilder : MonoBehaviour
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



    public void InitialPartsSetup(List<GameObject> p, Unit newOwnerUnit)
    {
        StartCoroutine(placeParts(p, newOwnerUnit));
    }


    IEnumerator placeParts(List<GameObject> p, Unit ownerUnit)
    {
        
        

        Destroy(legs);
        GameObject newPart = null;

        Destroy(legs);
        newPart = Instantiate(p[0], this.gameObject.transform);
        newPart.transform.localPosition = Vector3.zero;
        newPart.transform.parent = ownerUnit.gameObject.transform;
        newPart.GetComponent<Legs>().AddToOwner(ownerUnit);
        ownerUnit.activeParts.Add(newPart);
        legs = newPart;
        //UILayer(legs);

        yield return null;

        GameObject partPos = Instantiate(partPosBase, legs.GetComponent<Legs>().bodyPoint.transform);
      
        partPos.transform.localPosition = Vector3.zero;
        partPos.transform.parent = this.gameObject.transform;
        legs.transform.parent = partPos.transform;
        PartPosHolder holderScript = partPos.GetComponent<PartPosHolder>();


        yield return null;

        Destroy(body);
        newPart = Instantiate(p[1], holderScript.torsoPoint);
        newPart.transform.localPosition = Vector3.zero;
        //newPart.transform.parent = ownerUnit.gameObject.transform;
        newPart.GetComponent<Torso>().AddToOwner(ownerUnit);
        ownerUnit.activeParts.Add(newPart);
        body = newPart;
        
        ownerUnit.torso = newPart;
        //UILayer(body);

        yield return null;
        Destroy(rArm);
        newPart = Instantiate(p[2], holderScript.RArmPoint);
        newPart.transform.localPosition = Vector3.zero;
        //newPart.transform.parent = ownerUnit.gameObject.transform;
        newPart.GetComponent<Arms>().side = LeftOrRight.Right;
        newPart.GetComponent<Arms>().AddToOwner(ownerUnit);
        ownerUnit.activeParts.Add(newPart);
        rArm = newPart;

        //UILayer(arms);
        yield return null;

 
        Destroy(lArm);
        newPart = Instantiate(p[3], holderScript.LArmPoint);
        newPart.transform.localPosition = Vector3.zero;
        newPart.GetComponent<Arms>().side = LeftOrRight.Left;
        //newPart.transform.parent = ownerUnit.gameObject.transform;
        newPart.GetComponent<Arms>().AddToOwner(ownerUnit);
        ownerUnit.activeParts.Add(newPart);
        lArm = newPart;
        //UILayer(arms);
        yield return null;

        Destroy(rWeapon);
        newPart = Instantiate(p[4], rArm.GetComponent<Arms>().weaponPoint);
        newPart.transform.localPosition = Vector3.zero;
        newPart.GetComponent<Weapon>().side = LeftOrRight.Right;
        newPart.GetComponent<Weapon>().AddToOwner(ownerUnit);
     
        rWeapon = newPart;
        yield return null;

        Destroy(lWeapon);
        newPart = Instantiate(p[5], lArm.GetComponent<Arms>().weaponPoint);
        newPart.transform.localPosition = Vector3.zero;
        newPart.GetComponent<Weapon>().side = LeftOrRight.Left;
        newPart.GetComponent<Weapon>().AddToOwner(ownerUnit);
        lWeapon = newPart;
        yield return null;

        ownerUnit.PartStatValues();
        ownerUnit.setHealth();
        ownerUnit.EnemyWeaponSelect(rWeapon.GetComponent<Weapon>());
    }



}
