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

    public override void EnemyWeaponSelect(Weapon newWeapon)
    {
        activeWeapon = newWeapon;
    }



    public override void Death()
    {
        Destroy(gameObject);
        EventManager.RecieveEndPlayerTurn();

    }



    public override void FindTarget()
    {
        StartCoroutine(FinalTargetSelect());

    }

    private IEnumerator FinalTargetSelect()
    {
        GridStats target = ChooseTarget(occupiedTile.SetTarget());

        

     
        yield return null;

        if(target) {
           //print("My target is " + target.unit.name);

               if (target.visited < weaponRange)
                {
                GameManager.Instance.NewGameState(GameState.EnemyAction, this);
            }
            /* else
             {
         if (target.unit == this)
         {
             GameManager.Instance.NewGameState(GameState.EnemyAction, this);
         }*/
            else
            {
                EventManager.ReciveFirstEnemyPos(target);
            }
          //  }
            

        } else
        {
            print("Enemy waited");
            acted = true;
            GameManager.Instance.NewGameState(GameState.EnemySelect, null); 
            
        }



        
        
       
    }


    public override void BeginAttack()
    {
        
        StartCoroutine(AttackTargetSelect());
    }


    private IEnumerator AttackTargetSelect()
    {
        //occupiedTile.owner.DisplayEnemyTileRange(occupiedTile, 1);

        GridStats target = ChooseTarget(occupiedTile.SetAttackTarget());

        print("Enemy Attack phase");

        acted=true;

        yield return null;

        if (target)
        {
            print("Attacking " + target.unit.name);

            target.unit.CallCombat();

        }
        else
        {
            print("Enemy did not attack");
            acted = true;
            GameManager.Instance.NewGameState(GameState.EnemySelect, null);
        }

        yield return null;

        //GameManager.Instance.NewGameState(GameState.EnemySelect, null);




    }


    public override void CallCombat()
    {

        EventManager.RecieveCombatStartRequest(GameManager.Instance.activeUnit, this);

    }




    private GridStats ChooseTarget(List<GridStats> allTargets)
    {
        if (allTargets.Count > 0 && allTargets != null)
        {
          ///  switch (enemyType)
            //{
              //  case 0:
                    return FindClosestUnit(allTargets);

              //  default:
                   // return null;

           // }
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

        print(currentClosest);

        if (allTargets.Count > 1 && currentClosest != null)
        {

            for (int i = 1; i < allTargets.Count; i++)
            {
                if (allTargets[i] != null)
                {

                    if (allTargets[i].visited < currentClosest.visited)
                    {
                        currentClosest = allTargets[i];
                    }
                }
            }
        }


     
        return currentClosest;

    }

    public override void BeginMovement(List<GameObject> tilePath)
    {
        print("Starting movement");
        movement.BeginEnemyMove(tilePath);
    }
}
