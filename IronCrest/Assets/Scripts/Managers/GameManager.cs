using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{

    public GameState State;

    public static GameManager Instance;

    public static event Action<GameState> OnGameStateChanged;

    public static event Action SpawnUnits;

    public Unit activeUnit;

    public List<GameObject> stockParts = new List<GameObject>();




    // Start is called before the first frame update
    void Start()
    {
        NewGameState(GameState.PartSelect, null);
    }

    private void Awake()
    {
        Instance = this;
    }


    public void NewGameState(GameState newState, Unit newActiveUnit)
    {

        State = newState;

        activeUnit = newActiveUnit;

        switch(newState)
        {
            case GameState.PlayerSpawn:
                //SpawnUnits();
                break;
            case GameState.EnemySpawn:
                NewGameState(GameState.PlayerSelect, null);
                break;
            case GameState.PlayerSelect:
                break;
            case GameState.PlayerMoveSelect:
                print("Player Move Selection Phase");
                break;
            case GameState.PlayerMove:
                print("Player Move Phase");
                break;
            case GameState.PlayerMenu:
                print("Player Menu Phase");
                break;
            case GameState.PlayerAction:
                print("Player Action Phase");
                break;
            case GameState.EnemySelect:
                print("Enemy Select Phase");
                break;
            case GameState.EnemyTargetSelect:
                break;
            case GameState.EnemyMove:
                break;
            case GameState.EnemyAction:
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }
    
}

public enum GameState
{
    PartSelect,

    PlayerSpawn,
    EnemySpawn,
    PlayerSelect,
    PlayerMoveSelect,
    PlayerMove,
    PlayerMenu,
    PlayerAction,
    EnemySelect,
    EnemyTargetSelect,
    EnemyMove,
    EnemyAction,
    StageComplete
}


public enum PlayerActionState
{

}
