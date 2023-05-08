using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arms : BasePart
{

    public int maxHealth;

    

    public int defence;

    public int crit;

    public int dex;

    public int might;

    public LeftOrRight side;

    public Transform weaponPoint;


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
        newOwner.health += health;
        newOwner.defense += defence;
        newOwner.crit += crit;
        newOwner.dex += dex;
        
    }
}
