using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildRobo : MonoBehaviour
{
    public List<GameObject> parts = new List<GameObject>();

    GameObject legs;

    GameObject body;

    GameObject arms;

    public bool displayMech;

    public MenuButtons menu;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(placeParts(parts));
    }

    public void InitialPartsSetup(List<GameObject> p)
    {
        StartCoroutine(placeParts(p));
    }

    // Update is called once per frame
    void Update()
    {
        /*if(parts != menu.parts)
        {
            parts = menu.parts;


            print("Match");

            StartCoroutine(placeParts(parts));
        }*/
        if(displayMech)
        {
            StartCoroutine(placeParts(menu.parts));
        }

        


    }


    IEnumerator placeParts(List<GameObject> p)
    {
        Destroy(legs);
        GameObject newPart = null;

            Destroy(legs);
            newPart = Instantiate(p[0], this.gameObject.transform);
            newPart.transform.localPosition = Vector3.zero;
            legs = newPart;
            //UILayer(legs);

            
            yield return null;
            Destroy(body);
            newPart = Instantiate(p[1], legs.GetComponent<Legs>().bodyPoint.transform);
            newPart.transform.localPosition = Vector3.zero;
            body = newPart;
            //UILayer(body);

            yield return null;
            Destroy(arms);
            newPart = Instantiate(p[2], body.GetComponent<Torso>().armPoint.transform);
            newPart.transform.localPosition = Vector3.zero;
            arms = newPart;
            //UILayer(arms);
            yield return null;

            
    }




    public void UILayer(GameObject p)
    {
        foreach (Transform child in p.transform)
        {
            child.gameObject.layer = gameObject.layer;
            foreach (Transform child2 in child.transform)
            {
                child2.gameObject.layer = gameObject.layer;
            }
        }
    }

    public void changeParts(GameObject newP, int pos)
    {
        parts[pos] = newP;
        //StartCoroutine(placeParts());
    }
    

}
