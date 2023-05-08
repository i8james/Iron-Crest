    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhase : MonoBehaviour
{
    //public TurnCycle turns;

    //public int turnNum = 0;
    //public Unit[] units;
    public List<Unit> units;

    public bool[] unitStatus;

    public GameState State;


    //GameState returns


    //Sets local unit list to unitSpawner's player unit list
    private void PlayerSpawn(List<Unit> newUnits)
    {
        units = newUnits;
    }

    private void PlayerSelectRequest()
    {

    }

    //newActiveUnitRequest in this script has gone through and is ready to be passed to game manager
    private void PlayerSelect()
    {

    }

    //OnMouseDown in GridStats has sent a new GameState which is ready to be passed to game manager
    private void PlayerMoveSelect()
    {

    }

    //TraversePath in UnitMovement has sent a new GameState request, CheckSwitchState will determine if PlayerPhase should end
    private void PlayerMove()
    {
        
            CheckSwitchState();
            
    }

    //PlayerActionMenu has sent a GameState which is ready to be passed to game manager 
    private void PlayerMenu(GameState newGameState)
    {

    }

    //OnMouseDown in GridStats has sent a Combat GameState request
    private void PlayerAction()
    {
        
    }



    //Functions

   
    private void Update()
    {
        //If the state is PlayerMove, when escape is pressed cancel movement and return to player selection
        if(State == GameState.PlayerMove)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                GameManager.Instance.activeUnit.PartStatValues();//.acted = false;
                GameManager.Instance.NewGameState(GameState.PlayerSelect, null);
            }
        }
    }


    //Check each unit to see if they have acted
    private bool CheckRoundOver()
    {
        for(int i = 0; i < units.Count; i++)
        {
            if (units[i] != null)
            {
                if (!units[i].acted)
                {
                    //Current turn does not end
                    return false;

                }
            }
        }
        //Current turn ends
        return true;
    }



    private void OnGameStateChanged(GameState newState)
    {

        State = newState; //Local state variable is set to a new state 

        /*if (newState == GameState.PlayerSelect)
        {
            //CheckSwitchState();
        }*/
        //If the state switches to player select, check if the round is over
        
    }

    private void ReciveEndPlayerTurn()
    {
        CheckSwitchState();
    }


    private void CheckSwitchState()
    {
        //Calls function to check if all units have acted
        if(CheckRoundOver())
        {

            for (int i = 0; i < units.Count; i++)
            {
                units[i].PartStatValues();
                //units[i].acted = false; 
    
            }
            GameManager.Instance.NewGameState(GameState.EnemySelect, null);
        } else
        {
            GameManager.Instance.NewGameState(GameState.PlayerSelect, null);
        }
    }



    private void Start()
    {
        //Delcare all event subscribers
        EventManager.SendNewActiveUnitRequest += newActiveUnitRequest;
        EventManager.SendMovePath += ReciveTilePath;
        GameManager.OnGameStateChanged += OnGameStateChanged;
        EventManager.SendEndPlayerTurn += ReciveEndPlayerTurn;
        EventManager.SendPlayerUnitList += PlayerSpawn;
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
        newUnitRequest.unit.initRotation = newUnitRequest.unit.gameObject.transform.rotation;

        GameManager.Instance.NewGameState(GameState.PlayerMove, newUnitRequest.unit);


    }

    


     
}
