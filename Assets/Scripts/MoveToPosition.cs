using System;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPosition : MonoBehaviour
{

    public GameObject Destination;

    private NavMeshAgent _navMeshAgent;

    private void Awake() {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        _navMeshAgent.SetDestination(Destination.transform.position);
    }
}
