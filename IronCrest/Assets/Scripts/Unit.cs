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
    public int move;
    public bool acted;

    public GameObject selection;

    public List<GameObject> parts = new List<GameObject>();





    // Start is called before the first frame update
    void Start()
    {
        /*Torso torso = GetComponentInChildren<Torso>();
        Legs legs = GetComponentInChildren<Legs>();
        Head head = GetComponentInChildren<Head>();
        health = torso.health;
        attack = torso.attack;
        defense = torso.defense;
        ac = torso.ac + legs.ac;
        crit = head.crit;
        move = legs.move;
        acted = false;*/
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void heal()
    {
        health += 10;
    }

    public void cli(int selection)
    {
        print(selection);
    }


    public void SwitchPart()
    {
        GameObject tempPart = parts[3];
        if (tempPart.GetComponent<Legs>())
        {
            parts[3] = parts[0];
            parts[1] = tempPart;
        } else if (tempPart.GetComponent<Torso>())
        {
            parts[3] = parts[1];
            parts[1] = tempPart;
        }
        else if (tempPart.GetComponent<Weapon>())
        {
            parts[3] = parts[1];
            parts[1] = tempPart;
        } else
        {
            print("Part type isn't found!");
        }


    }

}
