using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{

    
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
        
        for (int i = tilePath.Count - 1; i >= 0; i--)
        {
            gameObject.transform.position = tilePath[i].transform.position;
            yield return new WaitForSeconds(0.1f);
        }
        GameManager.Instance.NewGameState(GameState.PlayerMenu, GameManager.Instance.activeUnit);
        //EventManager.ClearGrid();
    }


    public void BeginEnemyMove(List<GameObject> tilePath)
    {
        StartCoroutine(TraversePath(tilePath));
    }

    public IEnumerator TraverseEnemyPath(List<GameObject> tilePath)
    {

        for (int i = tilePath.Count - 1; i >= 0; i--)
        {
            gameObject.transform.position = tilePath[i].transform.position;
            yield return new WaitForSeconds(0.1f);
        }
        GameManager.Instance.NewGameState(GameState.EnemyAction, GameManager.Instance.activeUnit);
        //EventManager.ClearGrid();
    }







}
