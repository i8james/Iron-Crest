using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{

    
    public List<GameObject> Waypoints;
    int currentWayPoint = 1;
    Rigidbody rigidB;
    [SerializeField]
    float movespeed = 5;

    public float rotationSpeed = 50f;

    public bool movement = false;

    public bool click;

    public GameObject mech;

    public bool isTurn;

    public bool isAction;

    public int x;

    public int y;

    public PlayerPhase phase;

    public Unit stats;

    public int moveRange = 5;

    public GameObject tile;

    public int weaponRange = 2;

    public bool finishedAttack;

    // Start is called before the first frame update
    void Start()
    {
        weaponRange = 2;
        moveRange = 5;
        rigidB = GetComponent<Rigidbody>();
        click = false;
        isTurn = false;
        isAction = false;
        finishedAttack = false;
    }

    

    // Update is called once per frame
    void Update()
    {

        if (!click && Input.GetMouseButtonDown(0) && isTurn)
        {
            currentWayPoint = 1;
            click = true;
            
        }
        if (click && isTurn)
        {
            
            Movement();
        }

        if (!click && Input.GetMouseButtonDown(0) && isAction)
        {
            currentWayPoint = 1;
            click = true;

        }

        if (click && isAction)
        {
            Attack();
            //Movement();
        }



    }

    public void IsTurn(GridBehavior grid)
    {
        //new Vector3(grid.gridArray[x, y].GetComponent<GridStats>().x, grid.gridArray[x, y].GetComponent<GridStats>().y);
        grid.StartTurn(this);

        click = false;
        isAction = false;
        isTurn = true;
        finishedAttack = false;
        
        
    }

    

    public void IsNotTurn()
    {
        isTurn = false;
        finishedAttack = false;
        Waypoints[0].GetComponent<GridStats>().unit = this.gameObject;
        phase.EndMove();
    }

    public void IsAction(GridBehavior grid)
    {
        grid.StartTurn(this);
        click = false;
        isTurn = false;
        isAction = true;

        
    }

    public void IsNotAction()
    {
        isAction = false;
        finishedAttack = true;
        phase.NextUnit();
    }

    void ChangeWaypoints(List<GameObject> newWaypoints)
    {
        
    }

    public Vector2 SetTarget()
    {
        return new Vector2(x, y);

    }

    void Attack()
    {
        print(Waypoints[0]);
        //Waypoints[0]
        print(this.gameObject.GetComponent<Unit>());

        phase.BeginCombat(this.gameObject.GetComponent<Unit>(), Waypoints[0].GetComponent<GridStats>().unit);

        movement = false;
        currentWayPoint = 1;
        click = false;
        IsNotAction();
    }

    void Movement()
    {
        if (movement && Waypoints.Count > 1)
        {
            if (Vector3.Distance(transform.position, Waypoints[Waypoints.Count - currentWayPoint].transform.position) < 1.25f)
            {
                if (Waypoints.Count - currentWayPoint > 0)
                {
                    transform.position = Waypoints[Waypoints.Count - currentWayPoint].transform.position;
                    currentWayPoint++;
                    

                } else if (currentWayPoint == Waypoints.Count)
                {
                    tile = Waypoints[0]; 
                    x = Waypoints[0].GetComponent<GridStats>().x;
                    y = Waypoints[0].GetComponent<GridStats>().y;
                    movement = false;
                    transform.position = Waypoints[0].transform.position;
                    click = false;
                    IsNotTurn();
                }
            }

                
                Vector3 _dir = (Waypoints[Waypoints.Count - currentWayPoint].transform.position - transform.position).normalized;

                rigidB.MovePosition(transform.position + _dir * movespeed * Time.deltaTime);

                if (_dir != Vector3.zero)
                {
                    mech.transform.rotation = Quaternion.LookRotation(_dir);
                }


                

        } else
        {
            transform.position = Waypoints[0].transform.position;
            movement = false;
            currentWayPoint = 1;
            x = Waypoints[0].GetComponent<GridStats>().x;
            y = Waypoints[0].GetComponent<GridStats>().y;
            click = false;
            

        }
    }





}
