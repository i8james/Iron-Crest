using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnChange : MonoBehaviour
{
    public List<Unit> playerUnits;
    public List<Enemy> enemyUnits;
    int turn;
    string victory;
    // Start is called before the first frame update
    void Start()
    {
        turn = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if ((ActionsUsed(playerUnits) == false) && (turn == 1))
        {
            ChangeTurn();
        }
        if ((enemyUnits.Count == 0) && (victory == "Rout"))
        {
            EndGame("Victory");
        }
        if (playerUnits.Count == 0)
        {
            EndGame("Defeat");
        }
    }

    public bool ActionsUsed(List<Unit> team)
    {
        bool remainingAction = false;
        for (int i = 0; i <= team.Count; i++)
        {
            if (team[i].acted)
            {
                remainingAction = true;
                break;     
            }
        }
        return remainingAction;
    }
    
    void ChangeTurn()
    {
       if (turn == 1)
       {
            turn--;
       }
       if (turn == 0)
       {
            turn++;
       }
    }

    void EndGame(string endType)
    {
        if (endType == "Victory")
        {

        }
        if (endType == "Defeat")
        {

        }
    }
}
