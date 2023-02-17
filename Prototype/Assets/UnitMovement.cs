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

    public int x;

    public int y;

    public int moveRange = 5;

    // Start is called before the first frame update
    void Start()
    {
        moveRange = 5;
        rigidB = GetComponent<Rigidbody>();
        click = false;
        isTurn = false;
    }

    

    // Update is called once per frame
    void Update()
    {

        if (!click && Input.GetMouseButtonDown(0) && isTurn)
        {
            currentWayPoint = 1;
            click = true;
            
        }
        if (click)
        {
            
            Movement();
        }
        



    }

    public void IsTurn()
    {
        isTurn = true;
    }

    public void IsNotTurn()
    {
        isTurn = false;
    }

    void ChangeWaypoints(List<GameObject> newWaypoints)
    {
        
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


                






            /*if (Waypoints[Waypoints.Count - currentWayPoint].GetComponent<GridStats>().direction == 1)
            {
                mech.transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            else
                    if (Waypoints[Waypoints.Count - currentWayPoint].GetComponent<GridStats>().direction == 2)
            {
                mech.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
                    if (Waypoints[Waypoints.Count - currentWayPoint].GetComponent<GridStats>().direction == 3)
            {
                mech.transform.rotation = Quaternion.Euler(0, -90, 0);
            }
            else
                    if (Waypoints[Waypoints.Count - currentWayPoint].GetComponent<GridStats>().direction == 4)
            {
                mech.transform.rotation = Quaternion.Euler(0, 90, 0);
            }*/

        } else
        {
            movement = false;
            currentWayPoint = 1;
            click = false;
            

        }
    }





}
