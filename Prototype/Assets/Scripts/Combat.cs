using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    //GameObject GameManager = GameObject.Find("GameManager");
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            attack(GameObject.Find("Enemy"));
            
            //Calls to my combat cinematics script
        }
    }
    public void attack(GameObject defender)
    {
        Unit unit = GameObject.Find("Player").GetComponent<Unit>();
        Unit target = defender.GetComponent<Unit>();
        if (unit.w1Ammo > 0)
        {
            if (CalculateHit(target.ac))
            {
                if (UnityEngine.Random.Range(0, 100) <= unit.crit)
                {
                    int part = UnityEngine.Random.Range(1, 4);
                    target.health -= Damage(unit.attack, target.defense) * 3;
                    if (part == 1)
                    {
                        target.torsoHealth -= Damage(unit.attack, target.defense);
                    }
                    else if (part == 2)
                    {
                        target.armHealth -= Damage(unit.attack, target.defense);
                    }
                    else if (part == 3)
                    {
                        target.legHealth -= Damage(unit.attack, target.defense);
                    }
                    else
                    {
                        target.headHealth -= Damage(unit.attack, target.defense);
                    }
                }
                else
                {
                    int part = UnityEngine.Random.Range(1, 4);
                    target.health -= Damage(unit.attack, target.defense);
                    if (part == 1)
                    {
                        target.torsoHealth -= (int)(0.25 * Damage(unit.attack, target.defense));
                    }
                    else if (part == 2) 
                    {
                        target.armHealth -= (int)(0.25 * Damage(unit.attack, target.defense));
                    }
                    else if (part == 3)
                    {
                        target.legHealth -= (int)(0.25 * Damage(unit.attack, target.defense));
                    }
                    else
                    {
                        target.headHealth -= (int)(0.25 * Damage(unit.attack, target.defense));
                    }
                }
                if (target.health <= 0)
                {
                    Destroy(target);
                }
            }
            unit.consumeAmmo();
        }
    }

    //I have no idea how this hit rate calculation works
    public bool CalculateHit(int dodge)
    {
        int hitRate = 100 - dodge;
        double rint = UnityEngine.Random.Range(0, 100);
        if (hitRate <= rint)
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

    public void heal(GameObject target)
    {
        Unit healee = target.GetComponent<Unit>();
        if (healee.health <= healee.maxHealth - 10) {
            healee.health += 10;
        }
        else
        {
            healee.health += healee.maxHealth - healee.health;
        }
        
    }
}