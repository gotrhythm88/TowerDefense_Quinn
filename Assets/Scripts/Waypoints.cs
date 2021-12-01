using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] waypointlist;

    void Awake(){
        waypointlist = new Transform[transform.childCount];
        for (int i = 0; i < waypointlist.Length; i++)
        {
            waypointlist[i] = transform.GetChild(i);
        }
    }
}
