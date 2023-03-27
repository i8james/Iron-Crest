using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int health;
    public int attack;
    public int defense;
    public int ac;
    public int crit;
    public int move;
    public bool acted;
    public int range;
    public int moveRange;
    public int weaponRange;

    public GridStats initTile;

    public GridStats occupiedTile;


    public UnitMovement movement;

    public BuildRobo builder;

    public GameObject selection;

    public GameObject unitHolder;

    public int targetDetectRange = 15;

    public List<GameObject> parts = new List<GameObject>();




    


    // Start is called before the first frame update
    void Start()
    {
        /*Torso torso = GetComponentInChildren<Torso>();
        Legs legs = GetComponentInChildren<Legs>();
        Head head = GetComponentInChildren<Head>();
        health = torso.health;
        attack = torso.attack;
        defense = torso.defense;
        ac = torso.ac + legs.ac;
        crit = head.crit;
        move = legs.move;
        acted = false;*/

        //occupiedTile.unit = this;
        //transform.position = occupiedTile.transform.position;

        
    }


    
    public virtual void FindTarget()
    {
        print("Called FindTarget in a non enemy class");
    }

    public int ReturnType()
    {
        //0 is base, 1 is player, 2 is enemy
        return 0;
    }


    public void CancelMovement()
    {

        occupiedTile.unit = null;
        occupiedTile = initTile;
        initTile.unit = this;
        gameObject.transform.position = initTile.transform.position;
        GameManager.Instance.NewGameState(GameState.PlayerMove, this);
    }

    // Update is called once per frame

    private void Awake()
    {

        //Subscribe to events
        
        movement = gameObject.AddComponent<UnitMovement>();
        

        //Build body
        builder = unitHolder.AddComponent<BuildRobo>();
        builder.parts = parts;
        builder.InitialPartsSetup(parts);

    }

    //Update occupied tile
    public void ChangeOccupiedTile(GridStats newTile)
    {
        occupiedTile.unit = null;
        occupiedTile = newTile.GetComponent<GridStats>();
        newTile.unit = this;
        acted = true;

    }

    public void BeginMovement(List<GameObject> tilePath)
    {

    }

    

    public void heal()
    {
        health += 10;
    }

    public void cli(int selection)
    {
        print(selection);
    }


    public void SwitchPart()
    {
        GameObject tempPart = parts[3];
        if (tempPart.GetComponent<Legs>())
        {
            parts[3] = parts[0];
            parts[1] = tempPart;
        } else if (tempPart.GetComponent<Torso>())
        {
            parts[3] = parts[1];
            parts[1] = tempPart;
        }
        else if (tempPart.GetComponent<Weapon>())
        {
            parts[3] = parts[1];
            parts[1] = tempPart;
        } else
        {
            print("Part type isn't found!");
        }


    }

    

}
