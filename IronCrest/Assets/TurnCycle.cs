using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCycle : MonoBehaviour
{

    public int turnNum = 0;
    public GameObject[] units;
    public GridBehavior grid;

    private GameObject activeUnit;

    public bool nextUnit;

    public Camera cam;


    // Start is called before the first frame update
    void Start()
    {
        turnNum = 0;
        nextUnit = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (nextUnit)
        {
            
                if (turnNum == units.Length - 1)
                {
                    nextUnit = false;
                    
                    activeUnit = units[turnNum];
                    grid.unit = units[turnNum];
                    cam.target = units[turnNum];
                    grid.StartTurn();

                    if (activeUnit.GetComponent<UnitMovement>() != null)
                    {
                        activeUnit.GetComponent<UnitMovement>().IsTurn();
                    } else if (activeUnit.GetComponent<EnemyMovement>() != null)
                    {
                        activeUnit.GetComponent<EnemyMovement>().IsTurn();
                    }

                    turnNum = 0;
            }
                else
                {
                    nextUnit = false;
                    
                    activeUnit = units[turnNum];
                    grid.unit = units[turnNum];
                    cam.target = units[turnNum];
                    grid.StartTurn();

                    if (activeUnit.GetComponent<UnitMovement>() != null)
                    {
                        activeUnit.GetComponent<UnitMovement>().IsTurn();
                    }
                    else if (activeUnit.GetComponent<EnemyMovement>() != null)
                    {
                        activeUnit.GetComponent<EnemyMovement>().IsTurn();
                    }

                turnNum++;
            }


            
        }

        if (activeUnit != null)
        {
            if (activeUnit.GetComponent<UnitMovement>() != null)
            {
                if(activeUnit.GetComponent<UnitMovement>().isTurn == false)
                {
                    nextUnit = true;
                }
            } else if (activeUnit.GetComponent<EnemyMovement>() != null)
            {
                if (activeUnit.GetComponent<EnemyMovement>().isTurn == false)
                {
                    nextUnit = true;
                }
            }
        }




        
        
    }








}
