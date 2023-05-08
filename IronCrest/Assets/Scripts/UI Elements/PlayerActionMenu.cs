using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerActionMenu : MonoBehaviour
{
    public Image rWeaponIcon;

    public Image lWeaponIcon;
    

    private void Start()
    {
        GameManager.OnGameStateChanged += OnGameStateChange;
    }

    private void OnGameStateChange(GameState newState)
    {
        if(newState == GameState.PlayerMenu)
        {
            rWeaponIcon.sprite = GameManager.Instance.activeUnit.build2.rWeapon.GetComponent<Weapon>().partIcon;
            lWeaponIcon.sprite = GameManager.Instance.activeUnit.build2.lWeapon.GetComponent<Weapon>().partIcon;

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
                BeginAttack(LeftOrRight.Right);
                break;
            case 2:
                CancelMovement();
                break;
            case 3:
                Wait();
                break;
            case 4:
                BeginAttack(LeftOrRight.Left);
                break;
            default:
                print("Error, invalid selection");
                break;
        }
    }


    private void BeginAttack(LeftOrRight choice)
    {
        GameManager.Instance.activeUnit.PickWeapon(choice);
        //GameManager.Instance.NewGameState(GameState.PlayerAction, GameManager.Instance.activeUnit);
        print("Selected Attack");
    }

    private void CancelMovement()
    {
        GameManager.Instance.activeUnit.CancelMovement();
    }

    private void Wait()
    {
        //GameManager.Instance.NewGameState(GameState.PlayerSelect, null);
        EventManager.RecieveEndPlayerTurn();
    }

}
