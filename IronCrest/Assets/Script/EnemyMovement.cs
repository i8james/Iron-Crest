using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public List<GameObject> Waypoints;
    int currentWayPoint = 1;
    Rigidbody rigidB;
    [SerializeField]
    float movespeed = 5;

    public float rotationSpeed = 50f;

    public bool movement = false;

    public bool click;

    public bool click2;

    public GameObject mech;

    public bool isTurn;

    public int x;

    public int y;

    public GameObject[] units;

    public GridBehavior owner;

    public int moveRange = 30;

    public int realRange = 4;

    public int close = 0;

    public EnemyPhase phase;

    public bool isAction;

    // Start is called before the first frame update
    void Start()
    {
        moveRange = 30;
        rigidB = GetComponent<Rigidbody>();
        click = false;
        isTurn = false;
    }





    // Update is called once per frame
    void Update()
    {

        if (!click && isTurn)
        {
            //Pathfind();
            units[0].GetComponent<UnitMovement>().tile.GetComponent<GridStats>().setTarget();
            click = true;
        }

        if (click && isTurn)
        {
            FindPath();

        }

        if (isAction)
        {
            Movement();

        }




    }

    public void FindPath()
    {
        if (Waypoints.Count >= 1)
        {
            if (Waypoints.Count >= realRange + 1)
            {
                close = 0;
                Waypoints[Waypoints.Count - realRange].GetComponent<GridStats>().setTarget();
                IsNotTurn();

            } else
            {
                close = 1;
                //IsNotTurn();
                //IsAction(owner);
                Waypoints[1].GetComponent<GridStats>().setTarget();
                IsNotTurn();
            }
        }
    }

    public void IsTurn()
    {
        owner.enemyPhase = true;
        owner.maxMove = 15;
        click = false;
        isTurn = true;
        isAction = false;
        //close = 0;
        
    }

    public void IsNotTurn()
    {
        click = false;
        //owner.enemyPhase = false;
        isTurn = false;
        Waypoints[0].GetComponent<GridStats>().unit = this.gameObject;
        phase.EndMove();
    }

    public void IsAction(GridBehavior grid)
    {
        grid.StartTurn(this);
        click = false;
        isTurn = false;
        isAction = true;
        Waypoints = grid.path;
    }

    public void IsNotAction()
    {
        owner.enemyPhase = false;
        isAction = false;
        phase.NextUnit();
    }

 

    void Movement()
    {
        if (movement && Waypoints.Count > 1)
        {
            if (Vector3.Distance(transform.position, Waypoints[Waypoints.Count - currentWayPoint].transform.position) < 1.25f)
            {
                if (Waypoints.Count - currentWayPoint > 0) // 
                {
                    //transform.position = Waypoints[Waypoints.Count - currentWayPoint - close].transform.position;
                    currentWayPoint++;


                }
                else if (currentWayPoint == Waypoints.Count)
                {

                    x = Waypoints[0].GetComponent<GridStats>().x;
                    y = Waypoints[0].GetComponent<GridStats>().y;
                    movement = false;
                    transform.position = Waypoints[0].transform.position;
                    currentWayPoint = 1;
                    click = false;
                    
                    IsNotAction();
                }
            }
            

                Vector3 _dir = (Waypoints[Waypoints.Count - currentWayPoint].transform.position - transform.position).normalized;

                rigidB.MovePosition(transform.position + _dir * movespeed * Time.deltaTime);

                if (_dir != Vector3.zero)
                {
                    mech.transform.rotation = Quaternion.LookRotation(_dir);
                }
        }
        else
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

/*
 * if (movement && Waypoints.Count > 1 + close)
        {
            if (Vector3.Distance(transform.position, Waypoints[Waypoints.Count - currentWayPoint - close].transform.position) < 1.25f)
            {
                if (Waypoints.Count - currentWayPoint > 0 + close) // 
                {
                    //transform.position = Waypoints[Waypoints.Count - currentWayPoint - close].transform.position;
                    currentWayPoint++;


                }
                else if (currentWayPoint == Waypoints.Count - close)
                {

                    x = Waypoints[0 + close].GetComponent<GridStats>().x;
                    y = Waypoints[0 + close].GetComponent<GridStats>().y;
                    movement = false;
                    transform.position = Waypoints[0 + close].transform.position;
                    currentWayPoint = 1;
                    click = false;
                    
                    IsNotAction();
                }
            }
            

                Vector3 _dir = (Waypoints[Waypoints.Count - currentWayPoint].transform.position - transform.position).normalized;

                rigidB.MovePosition(transform.position + _dir * movespeed * Time.deltaTime);

                if (_dir != Vector3.zero)
                {
                    mech.transform.rotation = Quaternion.LookRotation(_dir);
                }
        }
        else
        {
            transform.position = Waypoints[0].transform.position;
            movement = false;
            currentWayPoint = 1;
            x = Waypoints[0].GetComponent<GridStats>().x;
            y = Waypoints[0].GetComponent<GridStats>().y;
            click = false;


        }
*/
