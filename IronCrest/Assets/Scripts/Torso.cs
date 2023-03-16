using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torso : MonoBehaviour
{
    public int health;
    public int ac;
    public int attack;
    public int defense;

    public bool buildMenu;

    public Material hover;

    public Unit owner;

    public GameObject armPoint;

    //public GameObject legs;
    //public GameObject body;
    //public GameObject arms;

    public GameObject self;

    //public GameObject select;

    public Camera cam;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //var ray : Ray = cam.ScreenPointToRay(Input.mousePosition);

    }



    private void OnMouseOver()
    {
        
    }

    

}
