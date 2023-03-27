using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.Space))
        {
            attack(GameObject.Find("Enemy"));
        }*/
    }

    public void attack(Unit unit, GameObject defender)
    {


       
        Enemy target = defender.GetComponent<Enemy>();
        if (CalculateHit(target.ac))
        {
            if (UnityEngine.Random.Range(0, 100) <= unit.crit)
            {
                target.health -= Damage(unit.attack, target.defense) * 3;
                print("I hit a crit on " + target.name + "!");
            }
            else
            {
                target.health -= Damage(unit.attack, target.defense);
                print("I hit " + target.name + "!");
            }
            if (target.health <= 0)
            {
                target.death();
            }
        }
    }

    public bool CalculateHit(int dodge)
    {
        int rint = UnityEngine.Random.Range(0, 100);
        if (rint <= 100 - dodge)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public int Damage(int attack, int defense)
    {
        return (attack - defense);
    }

}

