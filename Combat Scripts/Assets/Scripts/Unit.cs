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
        health = 10;
        attack = 10;
        defense = 2;
        ac = 20;
        crit = 10;
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
