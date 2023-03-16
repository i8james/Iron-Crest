using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnCycle : MonoBehaviour
{

    //public int turnNum = 0;
    public GameObject[] units;
    public GridBehavior grid;

    private GameObject activeUnit;

    public bool nextUnit;

    public Camera cam;

    public bool attackRound;

    public bool attacking;

    public PlayerPhase pPhase;

    public EnemyPhase ePhase;

    public GameObject actionMenu;

    public bool waitForCutscene;

    public GameObject dialogueBox;

    //jump to attack function 
    //maybe itnitative but items can modify that 
    //seperate player and enemy phase scripts 




    // Start is called before the first frame update
    void Start()
    {
        //turnNum = 0;
        nextUnit = true;
        actionMenu.SetActive(false);
        waitForCutscene = true;
        dialogueBox.SetActive(true);
        //pPhase.BeginPhase();
    }

    // Update is called once per frame
    void Update()
    {
        if (waitForCutscene)
        {
            if(Input.GetMouseButtonDown(0))
            {
                waitForCutscene=false;
                dialogueBox.SetActive(false);
                pPhase.BeginPhase();
            }
        }












    }




    public void DoIAttack(int choice) {

        actionMenu.SetActive(false);

        switch (choice)
        {
            case 0:
                pPhase.BeginAttack();
                break;

            case 1:
                pPhase.UndoMove();
                break;

            case 2: 
                pPhase.NextUnit();
                break;
            case 3:
                QuickPart();
                break;

            default:
                print("Case not found in menu selection!");
                break;
        }


    }

    public void QuickPart()
    {
        print("Switched Parts!");
        pPhase.NextUnit();
    }


    public void SwitchPhase(int playOrEnem) 
        //0 is player phase, 1 is enemy phase, 2 is ally phase
    {
        switch (playOrEnem)
        {
            case 0: 
                pPhase.BeginPhase();
                break;

            case 1:
                ePhase.BeginPhase();
                break;

            default:
                print("Can't switch phase!");
                break;

        }
    }

    public void DisplayMenu()
    {
        actionMenu.SetActive(true);
    }







}
