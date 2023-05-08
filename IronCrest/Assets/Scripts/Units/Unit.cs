using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public int maxHealth;
    public int health;
    public int attack;
    public int might;
    public int dex;
    public int defense;
    public int ac;
    public int crit;
    public int move;
    public bool acted;
    public int range;
    public int moveRange;
    public int weaponRange;

    public int rWeaponRange;

    public int lWeaponRange;


    public GridStats initTile;

    public Quaternion initRotation;

    public GridStats occupiedTile;


    public UnitMovement movement;

    public BuildRobo builder;

    public PartBuilder build2;

    public GameObject selection;

    public GameObject unitHolder;

    public int targetDetectRange = 15;

    public List<GameObject> parts = new List<GameObject>();

    public GameObject partPosBase;

    public UnitType unitType;

    public Transform healthBarPoint;

    public Weapon activeWeapon;

    public GameObject torso;

    public List<GameObject> activeParts = new List<GameObject>();

    public bool partSelector;


    public void Explode()
    {
        //torso.GetComponent<Torso>().Explode();
        StartCoroutine(Explosion());
       // torso.GetComponent<Torso>().Explode2(activeParts[Random.Range(0, activeParts.Count)]);
    }
    
    private IEnumerator Explosion()
    {
        GameObject exp = Instantiate(torso.GetComponent<Torso>().smallExplosion, torso.transform);
        exp.transform.localScale = Vector3.one * 0.35f;
        exp.transform.position = activeParts[Random.Range(0, activeParts.Count)].transform.position; //torso.transform.position;
        //exp.transform.position = Vector3.zero;
        yield return new WaitForSeconds(1f);
        Destroy(exp);
    }

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

        //PartStatValues();

        //Subscribe to events

        
    }

    public virtual void Death() {

    }

    public void PickWeapon(LeftOrRight choice)
    {
        switch(choice)
        {
            case LeftOrRight.Left:
                activeWeapon = build2.lWeapon.GetComponent<Weapon>();
                activeWeapon.EquipAddToOwner(this);
                
                break;
            case LeftOrRight.Right:
                activeWeapon = build2.rWeapon.GetComponent<Weapon>();
                activeWeapon.EquipAddToOwner(this);
                break;
        }

        GameManager.Instance.NewGameState(GameState.PlayerAction, GameManager.Instance.activeUnit);
    }


    


    public virtual void CallCombat() {

       
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


    public virtual void BeginAttack()
    {

    }

    public void CancelMovement()
    {

        occupiedTile.unit = null;
        occupiedTile = initTile;
        initTile.unit = this;
        gameObject.transform.rotation = initRotation;
        gameObject.transform.position = initTile.transform.position;
        GameManager.Instance.NewGameState(GameState.PlayerMove, this);
    }

    // Update is called once per frame

    private void Awake()
    {
        //
        if (!partSelector)
        {
          //  GameManager.OnGameStateChanged += Spawn;
        }
    }



    private void Spawn(GameState newGameState)
    {
        if (newGameState == GameState.PlayerSpawn)
        {
            StartCoroutine(PartStart());
        }
    }

    private IEnumerator PartStart()
    {
        movement = gameObject.AddComponent<UnitMovement>();

        yield return null;

        build2 = unitHolder.AddComponent<PartBuilder>();
        build2.partPosBase = partPosBase;
        build2.parts = parts;

        yield return null;

        build2.InitialPartsSetup(parts, this);

        yield return null;

        EventManager.ReciveHealthBarPos(healthBarPoint, this);
    }

    


    public void PartStatValues()
    {
        
        /*
          Torso torso = GetComponentInChildren<Torso>();
          Legs legs = GetComponentInChildren<Legs>();
          Head head = GetComponentInChildren<Head>();
          health = torso.health;
        

          attack = torso.attack;
          defense = torso.defense;
          ac = torso.ac + legs.ac;
          //crit = head.crit;
          move = legs.move;*/ 
          if(rWeaponRange >= lWeaponRange)
        {
            weaponRange = rWeaponRange;
        } else
        {
            weaponRange = lWeaponRange;
        }
        
          acted = false;

        //occupiedTile.unit = this;
        //transform.position = occupiedTile.transform.position;
    }

    public virtual void EnemyWeaponSelect(Weapon newWeapon)
    {

    }

    public void setHealth()
    {
        maxHealth = health;
    }

    //Update occupied tile
    public void ChangeOccupiedTile(GridStats newTile)
    {
        occupiedTile.unit = null;
        occupiedTile = newTile.GetComponent<GridStats>();
        newTile.unit = this;
        acted = true;

    }

    public virtual void BeginMovement(List<GameObject> tilePath)
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


public enum UnitType
{
    PlayerUnit,
    EnemyUnit,
    AllyUnits
}
