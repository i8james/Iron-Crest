using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shmovin : MonoBehaviour
{
    [SerializeField]
    Transform[] waypoints;
    int currentWayPoint = 0;
    Rigidbody rigidB;
    [SerializeField]
    float movespeed = 5;
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

    void Movement()
    {
        if(Vector3.Distance(transform.position, waypoints[currentWayPoint].position) < .25f) {
            currentWayPoint++;
            currentWayPoint = currentWayPoint % waypoints.Length;
        }
        Vector3 _dir = (waypoints[currentWayPoint].position - transform.position).normalized;
        rigidB.MovePosition(transform.position + _dir * movespeed * Time.deltaTime);
    }
}
