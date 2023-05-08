using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    private float moveSpeed = 0.007f;
    
    private void Start()
    {
        //EventManager.SendMovePath += BeginMove;
    }

    public void BeginMove(List<GameObject> tilePath)
    {
        StartCoroutine(TraversePath(tilePath));
    }

    public IEnumerator TraversePath(List<GameObject> tilePath)
    {
        EventManager.ReciveCamLock(true);

        for (int i = tilePath.Count - 1; i >= 0; i--)
        {
        
            if (i != 0)
            {
                gameObject.transform.LookAt(tilePath[i - 1].transform.position);

                Vector3 offset = tilePath[i].transform.position - tilePath[i - 1].transform.position;

                for (int x = 0; x < 10; x++)
                {
                   
                    gameObject.transform.position = tilePath[i].transform.position - (offset * (x * 0.1f));
                    
                    yield return new WaitForSeconds(moveSpeed);
                }

                gameObject.transform.position = tilePath[i - 1].transform.position;
               
            }
        }
        EventManager.ReciveCamLock(false);
        GameManager.Instance.NewGameState(GameState.PlayerMenu, GameManager.Instance.activeUnit);
        //EventManager.ClearGrid();
    }


    public void BeginEnemyMove(List<GameObject> tilePath)
    {
        StartCoroutine(TraverseEnemyPath(tilePath));
    }

    public IEnumerator TraverseEnemyPath(List<GameObject> tilePath)
    {
        //gameObject.transform.rotation = new Quaternion(0, -90f, 0, 0);
        EventManager.ReciveCamLock(true);

        for (int i = tilePath.Count - 1; i > 0; i--)
        {
            if (i != 0)
            {
                gameObject.transform.LookAt(tilePath[i - 1].transform.position);

                Vector3 offset = tilePath[i].transform.position - tilePath[i - 1].transform.position;

                for (int x = 0; x < 10; x++)
                {
                  
                    gameObject.transform.position = tilePath[i].transform.position - (offset * (x * 0.1f));
                  
                    yield return new WaitForSeconds(moveSpeed);
                }

                gameObject.transform.position = tilePath[i - 1].transform.position;
             
            }
        }
        //GameManager.Instance.NewGameState(GameState.EnemySelect, null);
        //GameManager.Instance.activeUnit.BeginAttack();
        EventManager.ReciveCamLock(false);
        GameManager.Instance.NewGameState(GameState.EnemyAction, GameManager.Instance.activeUnit);
    }



 



}
