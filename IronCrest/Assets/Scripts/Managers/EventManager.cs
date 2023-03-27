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

    public static event Action SendClearGrid;

    

    



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



}
