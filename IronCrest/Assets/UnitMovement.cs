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

    int moveRange;

    public bool movement = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidB = GetComponent<Rigidbody>();
        
    }

    

    // Update is called once per frame
    void Update()
    {
        Movement();



    }

    void ChangeWaypoints(List<GameObject> newWaypoints)
    {
        
    }

    void Movement()
    {
        if (movement)
        {
            if (Vector3.Distance(transform.position, Waypoints[Waypoints.Count - currentWayPoint].transform.position) < .25f)
            {
                if (Waypoints.Count - currentWayPoint > 0)
                {
                    currentWayPoint++;

                } else if (currentWayPoint == Waypoints.Count)
                {
                    movement = false;
                    currentWayPoint = 1;
                }
            }
            Vector3 _dir = (Waypoints[Waypoints.Count - currentWayPoint].transform.position - transform.position).normalized;
            rigidB.MovePosition(transform.position + _dir * movespeed * Time.deltaTime);
        }
    }





}
