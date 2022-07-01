using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(NavMeshAgent))]
public class Mover : MonoBehaviour
{
    private NavMeshAgent agent;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public void SetActorDestination(Vector3 destino)
    {
        agent.destination = destino;
    }

}
