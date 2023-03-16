using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhase : MonoBehaviour
{
    public TurnCycle turns;

    //public int turnNum = 0;
    public GameObject[] units;
    public bool[] unitStatus;
    public GridBehavior grid;

    private UnitMovement activeUnit;

    public bool nextUnit;

    public Camera cam;

    public bool attackRound;

    public bool attacking;

    public Vector2 initPos;

    public int currentTurn;

    public bool playerTurn;

    public bool unitSelected;

    public Combat combat;

    // Start is called before the first frame update
    void Start()
    {
        cam = turns.cam;
        grid = turns.grid;
        activeUnit = null;
        playerTurn = false;
        unitSelected = false;
        for (int i = 0; i < units.Length; i++)
        {
            units[i].GetComponent<UnitMovement>().phase = this;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BeginCombat(Unit player, GameObject enemy)
    {
        combat.attack(player, enemy);
    }


    public void BeginPhase()
    {
        currentTurn = 0;
        activeUnit = null;
        Turn(0);
        playerTurn = true;
    }

    public void SelectUnit(GameObject unit)
    {
        if (playerTurn)
        {
            if (!unitSelected)
                for (int i = 0; i < units.Length; i++)
                {
                    if (unit == units[i])
                    {
                        if (unitStatus[i] == true)
                        {
                            unitSelected = true;
                            MoveUnit(i);
                        }
                    }
                }
        }
    }


    public void SetTurns()
    {
        unitStatus = new bool[units.Length];

        for(int i = 0; i < units.Length; i++)
        {
            unitStatus[i] = true;
        }
    }
     

    public void EndPhase()
    {
        //activeUnit = null;
        playerTurn = false;
        turns.SwitchPhase(1); //change to one
        
    }

    public void Turn(int turnNum)
    {
        if (turnNum < units.Length)
        {
            MoveUnit(turnNum);
        } else
        {
            EndPhase();
            print("Switching phase!");
        }
    }

    public void MoveUnit(int turnNum)
    {
        

        currentTurn = turnNum;
        activeUnit = units[turnNum].GetComponent<UnitMovement>();
        grid.unit = units[turnNum];
        cam.target = units[turnNum];
        initPos = new Vector2(activeUnit.x, activeUnit.y);
        units[turnNum].transform.position = grid.gridArray[activeUnit.x, activeUnit.y].gameObject.transform.position;
        activeUnit.IsTurn(grid);
        grid.StartTurn(activeUnit);
    }


    public void EndMove()
    {
        activeUnit.GetComponent<UnitMovement>().click = true;
        grid.ClearGrid();
        turns.DisplayMenu();
    }

    public void BeginAttack()
    {
        //grid.StartTurn();
        activeUnit.GetComponent<UnitMovement>().IsAction(grid);
        grid.StartTurn(activeUnit);
    }


    public void NextUnit()
    {
        Turn(currentTurn + 1);
        //InactiveUnit();
        //unitSelected = false;


    }


    public IEnumerator InactiveUnit()
    {
        unitStatus[currentTurn] = false;

        bool unitFound = false;
        for (int i = 0; i < units.Length; i++)
        {
            if(unitStatus[i] == true)
            {
                unitFound = true;
            }
        }
        yield return null;
        if(!unitFound)
        {
            EndPhase();
            print("Switching phase!");
        }

    }

    public void UndoMove()
    {
        activeUnit.x = (int)initPos.x;
        activeUnit.y = (int)initPos.y;
        
        Turn(currentTurn);
        
    }

     
}
