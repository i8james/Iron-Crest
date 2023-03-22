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
        }
    }
    public void attack(GameObject defender)
    {
        Unit unit = GameObject.Find("Player").GetComponent<Unit>();
        Enemy target = defender.GetComponent<Enemy>();
        if (unit.w1Ammo > 0)
        {
            if (CalculateHit(target.ac))
            {
                if (UnityEngine.Random.Range(0, 100) <= unit.crit)
                {
                    target.health -= Damage(unit.attack, target.defense) * 3;
                }
                else
                {
                    target.health -= Damage(unit.attack, target.defense);
                }
                if (target.health <= 0)
                {
                    target.death();
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

