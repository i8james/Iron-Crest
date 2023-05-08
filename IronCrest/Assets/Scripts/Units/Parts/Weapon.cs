using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : BasePart
{
    public int minRange;
    public int maxRange;
    public int ammo;
    public int attack;
    public int crit;
    public int might;
    public int dex;

    public int numBulletsFired;

    public float fireRate;

    public LeftOrRight side;

    public WeaponType weaponType;

   // public float weight;





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
        if(side == LeftOrRight.Left)
        {
            newOwner.lWeaponRange = maxRange;
            
           
        } else if (side == LeftOrRight.Right)
        {
            newOwner.rWeaponRange = maxRange;
        }

        newOwner.PartStatValues();
   
    }

    public void EquipAddToOwner(Unit newOwner)
    {
        newOwner.weaponRange = maxRange;
        /*
        newOwner.crit += crit;
        newOwner.might += might;
        newOwner.dex += dex;*/
    }
}

public enum LeftOrRight {
    Left,
    Right
}

public enum WeaponType {
    Rifle,
    Melee,
    Rocket,
    MachineGun
}