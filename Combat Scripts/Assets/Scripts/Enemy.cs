using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int defense;
    public int ac;
    // Start is called before the first frame update
    void Start()
    {
        health = 10;
        defense = 2;
        ac = 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
