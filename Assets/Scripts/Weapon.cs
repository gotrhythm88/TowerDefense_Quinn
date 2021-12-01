using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform target = null;
    public string enemyTag = "Enemy";
    public float range = 10f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("RefreshTarget", 0f, 0.5f);
    }

    void RefreshTarget(){
        //find the closest enemy in range
        GameObject[] enemylist = GameObject.FindGameObjectsWithTag(enemyTag);
        
        float shortestDist = Mathf.Infinity;
        Transform closestEnemy = null;

        for(int i=0; i < enemylist.Length; i++){
            Vector3 diff = enemylist[i].transform.position - transform.position;
            float dist = diff.magnitude;
            if(dist < shortestDist){
                shortestDist = dist;
                closestEnemy = enemylist[i].transform;
            }
        }

        if(shortestDist < range){
            target = closestEnemy;
        }
        else{
            target = null;
        }
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

    // Update is called once per frame
    void Update()
    {
        if(target == null){
            return;
        }

        Vector3 targetDirection = target.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(targetDirection);
        transform.rotation = rotation;
    }
}
