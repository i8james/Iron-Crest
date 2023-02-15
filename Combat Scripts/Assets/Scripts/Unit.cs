using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int health;
    public int attack;
    public int defense;
    public int ac;
    public int crit;
    public bool acted;
    // Start is called before the first frame update
    void Start()
    {
        Torso torso = GetComponentInChildren<Torso>();
        Legs legs = GetComponentInChildren<Legs>();
        Head head = GetComponentInChildren<Head>();
        health = torso.health;
        attack = torso.attack;
        defense = torso.defense;
        ac = torso.ac + legs.ac;
        crit = head.crit;
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
}
