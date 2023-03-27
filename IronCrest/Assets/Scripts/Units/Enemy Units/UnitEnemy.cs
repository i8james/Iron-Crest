using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitEnemy : Unit
{
    public int enemyType = 0; //0 finds closest enemy, 1 finds weakest enemy, 2 picks randomly


    //public int targetDetectRange = 15;

    // Start is called before the first frame update
    void Start()
    {
        
    }

   




    public override void FindTarget()
    {
        StartCoroutine(FinalTargetSelect(ChooseTarget(occupiedTile.SetTarget())));

    }

    private IEnumerator FinalTargetSelect(GridStats target)
    {
        List<GameObject> pathToTarget = target.owner.CreateTilePath(target, this);

        yield return pathToTarget;

        if(pathToTarget.Count <= moveRange)
        {
            print("Moving withing range");
            for(int i = 0; i < pathToTarget.Count; i++)
            {
                print(pathToTarget[i].name);
            }
            pathToTarget[weaponRange - 1].GetComponent<GridStats>().owner.SendGridPath(pathToTarget[weaponRange - 1].GetComponent<GridStats>());
        
        } else
        {
            pathToTarget[(pathToTarget.Count - 1) - moveRange].GetComponent<GridStats>().owner.SendGridPath(pathToTarget[(pathToTarget.Count - 1) - moveRange].GetComponent<GridStats>());
        }
    }




    

    private GridStats ChooseTarget(List<GridStats> allTargets)
    {
        if (allTargets.Count > 0)
        {
            switch (enemyType)
            {
                case 0:
                    return FindClosestUnit(allTargets);

                default:
                    return null;

            }
        } else
        {
            return null;
        }

    }

    public new int ReturnType()
    {
        //0 is base, 1 is player, 2 is enemy
        return 2;
    }


    private GridStats FindClosestUnit(List<GridStats> allTargets)
    {
        GridStats currentClosest = allTargets[0];

        for(int i = 0; i < allTargets.Count; i++)
        {
            
            if (allTargets[i].x + allTargets[i].y < currentClosest.x + currentClosest.y)
            {
                currentClosest = allTargets[i];
            }
        }

        return currentClosest;

    }

    public new void BeginMovement(List<GameObject> tilePath)
    {
        print("Starting movement");
        movement.BeginEnemyMove(tilePath);
    }
}
