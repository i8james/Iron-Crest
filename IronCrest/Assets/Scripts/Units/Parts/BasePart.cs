using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePart : MonoBehaviour
{
    public int weight;
   // public int defence;
    public int health;
   // public int agility;
    

    public string partName;

    public int type;

    public string partDescription;

    public Sprite partIcon;

    public Transform floatingNumPoint;


    public bool gridPrePart;

    public bool broken;

    public void TakeDamage(int damage) {
        if(health - damage > 0) {
            health -= damage;
        } else {
            health = 0;
            broken = true;
        }
    }

    


 
}
