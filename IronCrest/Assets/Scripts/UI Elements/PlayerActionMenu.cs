using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActionMenu : MonoBehaviour
{
    

    private void Start()
    {
        GameManager.OnGameStateChanged += OnGameStateChange;
    }

    private void OnGameStateChange(GameState newState)
    {
        if(newState == GameState.PlayerMenu)
        {
            gameObject.SetActive(true);
        } else
        {
            gameObject.SetActive(false);
        }

       
    }

    public void MenuInput(int selection)
    {
        switch(selection)
        {
            case 1:
                BeginAttack();
                break;
            case 2:
                CancelMovement();
                break;
            case 3:
                Wait();
                break;
            default:
                print("Error, invalid selection");
                break;
        }
    }


    private void BeginAttack()
    {
        GameManager.Instance.NewGameState(GameState.PlayerAction, GameManager.Instance.activeUnit);
        print("Selected Attack");
    }

    private void CancelMovement()
    {
        GameManager.Instance.activeUnit.CancelMovement();
    }

    private void Wait()
    {
        GameManager.Instance.NewGameState(GameState.PlayerSelect, null);
    }

}
