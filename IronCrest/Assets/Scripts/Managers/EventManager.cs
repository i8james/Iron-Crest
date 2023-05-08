using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static event Action ExampleEvent;

    
    public static event Action<GameObject> AttackLocation;



    //Gridstats sends PlayerPhase a request to make its unit active when clicked
    public static event Action<GridStats> SendNewActiveUnitRequest;

    //Send active grid from GridStats to GridBehavior
    public static event Action<GridStats, bool> SendGridLocation;

    //Send movement waypoints from GridBehavior to UnitMovement
    public static event Action<List<GameObject>> SendMovePath;

    //Send movement waypoints from GridBehavior to UnitMovement
    public static event Action<List<GameObject>> SendDisplayMovePath;

    //Send active unit and action type for turn from current Phase to GridBehavior
    public static event Action<GameObject, int> SendActiveUnit;

    //Send location to attack from gridBehavior to current Phase
    public static event Action<GridStats> SendAttackLocation;


    public static event Action<List<GameObject>> SendTargetPath;


    public static event Action<GridStats> SendFirstEnemyPos;

    //Combat or PlayerActionMenu report to PlayerPhase that a unit's turn has ended 
    public static event Action SendEndPlayerTurn;

    

    public static event Action SendClearGrid;




    public static event Action<Unit, Unit> SendCombatStartRequest;


    public static event Action<List<Unit>> SendEnemyUnitList;

    public static event Action<List<Unit>> SendPlayerUnitList;

    public static event Action<int, Unit> SendPopUpStatus;

    public static event Action<Transform, Unit> SendHealthBarPos;

    public static event Action<bool> SendCamLock;

    public static void ReciveCamLock(bool status)
    {
        SendCamLock(status);
    }


    public static void ReciveHealthBarPos(Transform newHealthPos, Unit newOwner)
    {
        SendHealthBarPos(newHealthPos, newOwner);
    }

    public static void ReciveEnemyUnitList(List<Unit> EnemyList) {
        SendEnemyUnitList(EnemyList);
    }

    public static void RecivePlayerUnitList(List<Unit> PlayerList) {
        SendPlayerUnitList(PlayerList);
    }


    public static void RecieveCombatStartRequest(Unit attacker, Unit defender)
    {
        SendCombatStartRequest(attacker, defender);
    }


    public static void RecieveEndPlayerTurn()
    {
        SendEndPlayerTurn();
    }

    public static void ReciveTileDisplayLine(List<GameObject> newDisplayLine)
    {
      //  SendTileDisplayLine(newDisplayLine);
    }

    public static void ReceivePopUpStatus(int newPopUpStatus, Unit popUpUnit) {
        SendPopUpStatus(newPopUpStatus, popUpUnit);
    }




    public static void BeginEvent()
    {
        ExampleEvent?.Invoke();
    }

    public static void LocationReceived(GameObject target)
    {
        AttackLocation?.Invoke(target);
    }


        public static void ClearGrid()
        {
            SendClearGrid?.Invoke();
        }





    //Player Movement and Action Events 

        //Gridstats sends PlayerPhase a request to make its unit active when clicked
        public static void ReceiveNewActiveUnitRequest(GridStats thisTile)
        {
            SendNewActiveUnitRequest?.Invoke(thisTile);
        }


        //A tile's GridStats sends gridBehavior the tile hovered over, and if it is clicked
        public static void ReceiveGridLocation(GridStats thisTile, bool beginMove)
        {
            SendGridLocation?.Invoke(thisTile, beginMove);
        }

        //gridBehavior sends the active unit a path to their location
        public static void ReceiveMovePath(List<GameObject> path)
        {
            SendMovePath?.Invoke(path);
        }

        public static void ReciveDisplayMovePath(List<GameObject> path)
        {
            SendDisplayMovePath.Invoke(path);
        }

    //playerPhase or enemyPhase sends gridBehavior the active unit and which action to take
    public static void ReceiveActiveUnit(GameObject activeUnit, int actionPhase)
        {
            SendActiveUnit?.Invoke(activeUnit, actionPhase);
        }


        //gridBehavior sends the active unit a location to attack
        public static void ReceiveAttackLocation(GridStats targetTile)
        {
            SendAttackLocation?.Invoke(targetTile);
        }


    //Enemy Movement and Action Events
        
        public static void ReciveFirstEnemyPos(GridStats newTarget)
        {
            SendFirstEnemyPos(newTarget);
        }

        public static void ReciveTargetPath(List<GameObject> newTargetPath)
        {
            SendTargetPath(newTargetPath);
        }


}
