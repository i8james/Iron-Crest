using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButtons : MonoBehaviour 
    {

    public MenuTurn obj;

    private Quaternion initRot;

    public bool buttonManager;

    public List<GameObject> parts = new List<GameObject>();

    GameObject activePart;

    private float menuOffset;

    public bool slideMenu;

    public GameObject partHolder;

    bool opening;

    bool open;

    public List<GameObject> bodies = new List<GameObject>();

    public List<GameObject> arms = new List<GameObject>();

    public List<GameObject> legs = new List<GameObject>();

    public List<GameObject> activeList = new List<GameObject>();

    public GameObject currentPart;

    public MechBuiler previewMech;

    public int currentPartNum;

    // Start is called before the first frame update
    void Start()
    {
        open = false;
        opening = false;
        if (slideMenu)
        {
            transform.localPosition = new Vector3(90, 0, 706);
            //previewMech.ChangeArms(arms[0]);
            StartParts();
        }
        
        
    }



    public void StartParts()
    {
        parts[0] = legs[0];
        parts[1] = bodies[0];
        parts[2] = arms[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (slideMenu)
        {
            transform.localPosition = new Vector3(90f + menuOffset, 0f, 706f);
        }
    }

    public void MouseOver()
    {
        obj.mouseOver = true;
    }

    public void MouseOff()
    {
        obj.mouseOver = false;
        obj.resetRot();
    }

    public void OpenParts(int choice)
    {
        if (!open)
        {
            opening = true;
            //activePart = parts[choice];
            //activePart.SetActive(true);
            menuOffset = 0f;
            StartCoroutine("Slide");

            switch (choice)
            {
                case 0:
                    activeList = bodies;
                    activePart = Instantiate(parts[1], partHolder.transform);
                    //currentPartNum = choice;
                    currentPart = parts[1];
                    currentPartNum = 1;
                    break;
                case 1:
                    activeList = arms;
                    activePart = Instantiate(parts[2], partHolder.transform);
                    //currentPartNum = choice;
                    currentPart = parts[2];
                    currentPartNum = 2;
                    break;
                case 2:
                    activeList = legs;
                    activePart = Instantiate(parts[0], partHolder.transform);
                    //currentPartNum = choice;
                    currentPart = parts[0];
                    currentPartNum =  0;
                    break;

            }

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
            //activePart.transform.localPosition = Vector3.zero;



            activePart.transform.localScale = Vector3.one * 70;
            activePart.SetActive(true);





            /*

            opening = true;
            //activePart = parts[choice];
            //activePart.SetActive(true);
            menuOffset = 0f;
            StartCoroutine("Slide");
            activePart = Instantiate(parts[choice], partHolder.transform);
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
            //activePart.transform.localPosition = Vector3.zero;



            activePart.transform.localScale = Vector3.one * 70;
            activePart.SetActive(true);
            //previewMech.ChangeArms(); */
        }
        
    }

    void NewPart(GameObject newPart)
    {
        activePart = Instantiate(newPart, partHolder.transform);
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



        activePart.transform.localScale = Vector3.one * 70;
        activePart.SetActive(true);
        currentPart = newPart;
        parts[currentPartNum] = newPart;
        
        //previewMech.ChangeArms(newPart);
    }


    public void closeMenu()
    {
        if (open)
        {
            if (!opening)
            {
                opening = true;
                StartCoroutine(SlideBack());

            }
        }
    }


    IEnumerator Slide()
    {
        
        for (int i = 0; i < 13; i++)
        {
            menuOffset = i * 20;
            
            //print(menuOffset);
            yield return new WaitForSeconds(0.04f);
        }
        menuOffset = 260;
        opening = false;
        open = true;
    }

    IEnumerator SlideBack()
    {
        for (int i = 13; i > 0; i--)
        {
            menuOffset = i * 20;

            //print(menuOffset);
            yield return new WaitForSeconds(0.03f);
        }
        //activePart.SetActive(false);
        Destroy(activePart);
        menuOffset = 0;
        opening = false;
        open = false;
    }

    public int GetActive(GameObject g)
    {
        for (int i = 0; i < activeList.Count; i++)
        {
            if (activeList[i] == g)
            {
                return i;
            }
        }
        return 0;
    }


    public void scroll(int direction)
    {
        switch(direction)
        {
            case 0: //right
                print("here00");
                for(int i = 0;i< activeList.Count;i++)
                {
                    if(activeList[i] == currentPart)
                    {
                        int pos = i;
                        if(pos + 1 < activeList.Count)
                        {
                            Destroy(activePart);
                            //print("Yeah");
                            NewPart(activeList[pos + 1]);
                            
                            break;
                        } else
                        {
                            Destroy(activePart);
                            NewPart(activeList[0]);
                            break;
                        }
                    }
                }
                break;
            case 1: //lefft
                for (int i = 0; i < activeList.Count; i++)
                {
                    if (activeList[i] == currentPart)
                    {
                        int pos = i;
                        if (pos - 1 >= 0)
                        {
                            Destroy(activePart);
                            NewPart(activeList[pos - 1]);
                            break;
                        }
                        else
                        {
                            Destroy(activePart);
                            NewPart(activeList[activeList.Count - 1]);
                            break;
                        }
                    }
                }
                break;
        }
    }

}
 