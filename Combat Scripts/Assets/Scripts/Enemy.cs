using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int defense;
    public int ac;
    public int move;
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

    public void death()
    {
        Destroy(gameObject);
    }

    public GameObject FindTarget(List<GameObject> units)
    {
        GameObject idealUnit = units[0];
        for(int i = 1; i < units.Count; i++)
        {
            if ((DistanceTo(units[i]) < DistanceTo(idealUnit)) && (Advantage(units[i])))
            {
                idealUnit = units[i];
            }
            else if (DistanceTo(units[i]) < DistanceTo(idealUnit))
            {
                idealUnit = units[i];
            }
        }
        return idealUnit;
    }

    public int DistanceTo(GameObject target)
    {
        int distance = 0;
        return distance;
    }

    public bool Advantage(GameObject unit)
    {
        Unit target = unit.GetComponent<Unit>();
        if (target.move > move)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
