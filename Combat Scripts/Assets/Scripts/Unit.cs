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
    // Start is called before the first frame update
    void Start()
    {

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
