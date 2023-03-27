using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPhase : MonoBehaviour
{
    public UnitEnemy[] units;
    public bool[] unitStatus;

    public GameState State;

    private void Start()
    {
        GameManager.OnGameStateChanged += OnGameStateChange;
        EventManager.SendMovePath += ReciveTilePath;
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
    }

    private void UnitTurnCycle()
    {
        bool isEnemyTurnOver = true;
        for(int i = 0; i < units.Length; i++)
        {
            if(!units[i].acted)
            {
                isEnemyTurnOver = false;
                GameManager.Instance.NewGameState(GameState.EnemyMove, units[i]);
                break;
            }
        }
        if(isEnemyTurnOver)
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
        for (int i = 0;i < units.Length;i++)
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
