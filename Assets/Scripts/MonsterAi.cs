using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAi : NetworkBehaviour
{

    [SerializeField] LayerMask players,waypoint;

    private NavMeshAgent navMeshAgent;
    public bool EnemyInRange,EnemyInKillRange,noTarget;
    [SerializeField] float range,waypointRange, killrange;
    public int _numFound, _numFound2,_numFound3,destinationIndex;
    Collider[] _coliders = new Collider[3];
    Collider[] _coliders2 = new Collider[3];
    Collider[] _coliders3 = new Collider[3];
    [SerializeField] Canvas DeathScreen;
    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        noTarget = true;
    }

    // Update is called once per frame
    void Update()
    {

            _numFound = Physics.OverlapSphereNonAlloc(GetComponent<Transform>().position, 10f, _coliders, players);
            if (_numFound > 0)
            {

                //ChaseClientRpc();
                Chase();
            }
            else
            {

                Patrol();
                //PatrolClientRpc();

            }
        
    }

    private void Patrol()
    {
        if (noTarget) { 
            _numFound3 = Physics.OverlapSphereNonAlloc(GetComponent<Transform>().position, waypointRange, _coliders3, waypoint);
            SetDestinationClientRpc(destinationIndex);
            /*if (IsServer){
                SetDestinationClientRpc(destinationIndex);
            }*/
            navMeshAgent.SetDestination(_coliders3[destinationIndex].transform.position);
            noTarget = false;
            GetComponent<Animator>().Play ("Chodzenie");
        }
        Vector3 distance = _coliders3[destinationIndex].transform.position - transform.position;

        if(distance.magnitude < 1.5f)
        {
         
            noTarget = true;
        }
    }
    private void Chase()
    {
        
        _numFound2 = Physics.OverlapSphereNonAlloc(GetComponent<Transform>().position, killrange, _coliders2, players);
        if (_numFound2>0) {
            
            Kill();
        }
        else
        {
            GetComponent<Animator>().Play ("bieganie");
            navMeshAgent.SetDestination(_coliders[0].transform.position);
            noTarget= true;
        }
    }
    private void Kill()
    {
        GetComponent<Animator>().Play ("atak");
        DeathScreen.gameObject.SetActive(true);
    }



    /*
    [ServerRpc]
    void PatrolServerRpc()
    {

    }
    */
    [ClientRpc]
    void SetDestinationClientRpc(int index)
    {
        destinationIndex = UnityEngine.Random.Range(0, _numFound3);
    }

    [ServerRpc(RequireOwnership = false)]
    void ChaseServerRpc()
    {

    }

    [ClientRpc]
    void ChaseClientRpc()
    {
        Chase();
    }

}
