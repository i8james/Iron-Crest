using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPhase : MonoBehaviour
{
    //public UnitEnemy[] units;
    public List<Unit> units;

    public bool[] unitStatus;

    public GameState State;



    //UnitTurnCycle has sent a new active enemy unit for GameManager
    private void EnemySelect()
    {

    }

    //GridBehavior FindTargetPath has sent a new GameState request
    private void EnemyTargetSelect()
    {

    }

    //UnitMovement has sent a new GameState request
    private void EnemyMove()
    {

    }

    //UnitEnemy has sent a new Enemy Selection request
    private void EnemyAction()
    {

    }





    private void Start()
    {
        GameManager.OnGameStateChanged += OnGameStateChange;
        EventManager.SendTargetPath += ReciveTilePath;
        EventManager.SendEnemyUnitList += ReciveEnemyUnits;
    }

    private void ReciveEnemyUnits(List<Unit> newEnemyList) 
    {
        units = newEnemyList;
    }


    private void OnGameStateChange(GameState newState)
    {
        State = newState;

        if(newState == GameState.EnemySelect)
        {
            UnitTurnCycle();
        } else if (newState == GameState.EnemyMove)
        {
            EnemySelectTarget();
        }
        else if (newState == GameState.EnemyAction)
        {
            GameManager.Instance.activeUnit.BeginAttack();
        }
    }

    private void UnitTurnCycle()
    {
        bool allEnemiesDead = true;
        bool isEnemyTurnOver = true;
        for(int i = 0; i < units.Count; i++)
        {
            if(units[i] != null) {
                allEnemiesDead = false;
                if(!units[i].acted)
                {
                    isEnemyTurnOver = false;
                    GameManager.Instance.NewGameState(GameState.EnemyMove, units[i]);
                    break;
                }
            }
        }
        if(allEnemiesDead)
        {
            GameManager.Instance.NewGameState(GameState.StageComplete, null);
        } else if(isEnemyTurnOver)
        {
            ResetActed();
            GameManager.Instance.NewGameState(GameState.PlayerSelect, null);
        }

    }
    
    private void EnemySelectTarget()
    {
        GameManager.Instance.activeUnit.FindTarget();
    }

    private void ResetActed()
    {
        for (int i = 0;i < units.Count;i++)
        {
            units[i].acted = false;
        }
    }

    private void ReciveTilePath(List<GameObject> tilePath)
    {
        if (GameManager.Instance.State == GameState.EnemyMove)
        {

            GameManager.Instance.activeUnit.ChangeOccupiedTile(tilePath[0].GetComponent<GridStats>());

            print("Movement");

            GameManager.Instance.activeUnit.BeginMovement(tilePath);

        }
    }






}
