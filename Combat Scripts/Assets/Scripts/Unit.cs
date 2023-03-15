using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int health;
    public int maxHealth;
    public int attack;
    public int defense;
    public int ac;
    public int crit;
    public int w1Ammo;
    public int w2Ammo;
    public int w1Min;
    public int w1Max;
    public int w2Min;
    public int w2Max;
    public int move;
    public bool acted;
    // Start is called before the first frame update
    void Start()
    {
        Torso torso = GetComponentInChildren<Torso>();
        Legs legs = GetComponentInChildren<Legs>();
        Head head = GetComponentInChildren<Head>();
        Weapon weapon1 = GetComponentInChildren<Weapon>();
        health = torso.health;
        maxHealth = torso.health;
        attack = torso.attack + weapon1.attack;
        w1Ammo = weapon1.ammo;
        w1Min = weapon1.minRange;
        w1Max = weapon1.maxRange;
        defense = torso.defense;
        ac = torso.ac + legs.ac;
        crit = head.crit;
        move = legs.move;
        acted = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void heal()
    {
        health += 10;
    }

    public void consumeAmmo()
    {
        w1Ammo--;
    }
}
