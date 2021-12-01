using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f;
    public int waypoint_index = 0;
    private Transform current_waypoint;
    
    // Start is called before the first frame update
    void Start()
    {
        current_waypoint = Waypoints.waypointlist[waypoint_index];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = current_waypoint.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, current_waypoint.position) < 0.2f){
            NextWaypoint();
        }
    }

    private void NextWaypoint(){
        waypoint_index++;
        if(waypoint_index == Waypoints.waypointlist.Length){
            //reached the end
            Destroy(gameObject);
            return;
        }

        current_waypoint = Waypoints.waypointlist[waypoint_index];
    }
}
