using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private float speed = 5;
    public GameObject[] waypoints;
    private int currentWaypoint = 0;
    float previousSpeed = 0;

    // What the EEG should change and access
    public float stressDeviation = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        // Changing speed according to stress
        if (speed > 0) {
            if (stressDeviation != 0) {
                speed -= stressDeviation;
            } 
        }

        // Restarts loop
        if (currentWaypoint == 46) {
            currentWaypoint = 0;
        }

        // Waypoint index changer
        var distance = Vector3.Distance(transform.position, waypoints[currentWaypoint].transform.position);
        if (distance < 0.5f) {
            Console.WriteLine("whats good");
            currentWaypoint++;
        }

        // Position and angle changer
        float step = speed * Time.deltaTime;
        transform.LookAt(waypoints[currentWaypoint].transform.position);
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, step);
    }

    public void startStop() {
        speed = 0;

        if(speed > 0){
            previousSpeed = speed;
            speed = 0;
        } else {
            speed = previousSpeed;
        }
    }
}
