    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhase : MonoBehaviour
{
    //public TurnCycle turns;

    //public int turnNum = 0;
    public Unit[] units;
    public bool[] unitStatus;

    public GameState State;


   
    private void Update()
    {
        //If the state is PlayerMove, when escape is pressed cancel movement and return to player selection
        if(State == GameState.PlayerMove)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                GameManager.Instance.NewGameState(GameState.PlayerSelect, null);
            }
        }
    }


    //Check each unit to see if they have acted
    private bool CheckRoundOver()
    {
        for(int i = 0; i < units.Length; i++)
        {
            if(!units[i].acted)
            {
                //Current turn does not end
                return false;
                
            }
        }
        //Current turn ends
        return true;
    }



    private void OnGameStateChanged(GameState newState)
    {

        State = newState; //Local state variable is set to a new state 

        //If the state switches to player select, check if the round is over
        if(newState == GameState.PlayerSelect)
        {
            CheckSwitchState();
        } 
    }


    private void CheckSwitchState()
    {
        //Calls function to check if all units have acted
        if(CheckRoundOver())
        {

            for (int i = 0; i < units.Length; i++)
            {
                units[i].acted = false;
                print("New Round");
            }
            //GameManager.Instance.NewGameState(GameState.EnemySelect, null);
            GameManager.Instance.NewGameState(GameState.PlayerSelect, null);
        } 
    }



    private void Start()
    {
        //Delcare all event subscribers
        EventManager.SendNewActiveUnitRequest += newActiveUnitRequest;
        EventManager.SendMovePath += ReciveTilePath;
        GameManager.OnGameStateChanged += OnGameStateChanged;
    }

    //Receive movement path and begin to move across it
    private void ReciveTilePath(List<GameObject> tilePath)
    {
        if (GameManager.Instance.State == GameState.PlayerMoveSelect)
        {

            GameManager.Instance.activeUnit.ChangeOccupiedTile(tilePath[0].GetComponent<GridStats>());
    
            
            GameManager.Instance.activeUnit.movement.BeginMove(tilePath);
            
        }
    }




    //A tile requests for its unit to be made the active unit
    private void newActiveUnitRequest(GridStats newUnitRequest)
    {
        newUnitRequest.unit.initTile = newUnitRequest;
        GameManager.Instance.NewGameState(GameState.PlayerMove, newUnitRequest.unit);


    }

    


     
}
