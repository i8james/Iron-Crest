using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPhase : MonoBehaviour
{
    public TurnCycle turns;

    public GameObject[] units;
    public GridBehavior grid;

    private EnemyMovement activeUnit;

    public bool nextUnit;

    public Camera cam;

    public bool attackRound;

    public bool attacking;

    public Vector2 initPos;

    public int currentTurn;

    public GameObject caution;

    // Start is called before the first frame update
    void Start()
    {
        caution.SetActive(false);
        cam = turns.cam;
        grid = turns.grid;
        activeUnit = null;
        for (int i = 0; i < units.Length; i++)
        {
            units[i].GetComponent<EnemyMovement>().phase = this;
            //units[i].transform.position = grid.gridArray[units[i].GetComponent<EnemyMovement>().x, units[i].GetComponent<EnemyMovement>().y].gameObject.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BeginPhase()
    {
        caution.SetActive(true);
        currentTurn = 0;
        activeUnit = null;
        Turn(0);
    }


    public void EndPhase()
    {
        caution.SetActive(false);
        //activeUnit = null;
        turns.SwitchPhase(0); //change to one

    }

    public void Turn(int turnNum)
    {
        if (turnNum < units.Length)
        {
            MoveUnit(turnNum);
        }
        else
        {
            EndPhase();
            print("Switching phase!");
        }
    }

    public void MoveUnit(int turnNum)
    {

        grid.unit = units[turnNum];
        currentTurn = turnNum;
        activeUnit = units[turnNum].GetComponent<EnemyMovement>();
        
        cam.target = units[turnNum];
        units[turnNum].transform.position = grid.gridArray[activeUnit.x, activeUnit.y].gameObject.transform.position;
        activeUnit.IsTurn();
        grid.StartTurn(activeUnit);
    }


    public void EndMove()
    {
        BeginAttack();
    }

    public void BeginAttack()
    {
        //grid.StartTurn();
        activeUnit.GetComponent<EnemyMovement>().IsAction(grid);
        grid.StartTurn(activeUnit);
    }


    public void NextUnit()
    {
        Turn(currentTurn + 1);
    }

  
}
