using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legs : BasePart
{
    public int move;
    public int ac;
   
    public int might;
    

    public GameObject bodyPoint;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToOwner(Unit newOwner)
    {
        
        newOwner.moveRange = move;
        newOwner.ac += ac;
        newOwner.health += health;
        newOwner.might += might;
    }
}
