using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent nav;
    GameObject target;
    Vector3 targetPos;
    public int health = 2;
    Manager manager;
    void Start()
    {
        target = GameObject.FindWithTag("mainCharacter");
        nav = GetComponent<NavMeshAgent>();
        nav.updateRotation = false;
        manager = GameObject.FindGameObjectWithTag("manager").GetComponent<Manager>();
        //tween walking animation (rocking side to side)

    }
    public void gotHit() {
        health--;
        if (health <= 0) {
            manager.killedMonster();
            Destroy(this.gameObject);
        }
    }
    void FixedUpdate()
    {
        targetPos = target.transform.position;
        nav.SetDestination(targetPos);
        if (!nav.isStopped) {
            Vector3 dir = (targetPos - transform.position).normalized;
            
            transform.rotation= Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(dir), 360);
        }
    }
}
