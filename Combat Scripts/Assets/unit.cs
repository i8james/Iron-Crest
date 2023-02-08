using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unit : MonoBehaviour
{
    public int health;
    public int attack;
    public int defense;
    public int ac;
    public int crit;
    public int hit;
    // Start is called before the first frame update
    void Start()
    {
        health = 10;
        attack = 5;
        defense = 2;
        ac = 20;
        hit = 90;
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
