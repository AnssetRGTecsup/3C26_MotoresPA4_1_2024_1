using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private PlayerController playerReference;

    [SerializeField] NavMeshAgent EnemyAgent;

    [SerializeField] private List<Transform> PivotPositions;

    [SerializeField] private int pivotCounter = 0;
    [SerializeField] private int pivotPoints;
    [SerializeField] private int currentIndex;
    private Transform currentPivot;

    [SerializeField] EnemyDetectionZone enemyDetectionZone;
    [SerializeField] LayerMask layerMask;
    [SerializeField] private float viewDistance = 5;

    private void Awake()
    {
        pivotPoints = PivotPositions.Count - 1;
        currentIndex = 0;

        currentPivot = PivotPositions[currentIndex];
        EnemyAgent.SetDestination(currentPivot.position);

    }

    [ContextMenu("Add Counter")]
    private void UpdatePivot()
    {
        currentIndex = (int)Mathf.PingPong(++pivotCounter, pivotPoints);

        currentPivot = PivotPositions[currentIndex];

        EnemyAgent.SetDestination(currentPivot.position);   
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && playerReference.CurrentState == PlayerState.Normal && enemyDetectionZone.PlayerInColliderZone)
        {
            if (!Physics.Raycast(EnemyAgent.transform.position, EnemyAgent.transform.forward, Vector3.Distance(EnemyAgent.transform.position, other.transform.position), layerMask) ||
                !Physics.Raycast(EnemyAgent.transform.position, EnemyAgent.transform.forward, Vector3.Distance(EnemyAgent.transform.position, other.transform.position), layerMask))
            {
                Debug.DrawRay(EnemyAgent.transform.position, EnemyAgent.transform.forward * viewDistance, Color.green);
                EnemyAgent.SetDestination(other.transform.position);
            }
            else
            {
                Debug.DrawRay(EnemyAgent.transform.position, EnemyAgent.transform.forward * viewDistance, Color.red);
            }
        }
    }

    private void Update()
    {
        if (EnemyAgent.transform.position.x == currentPivot.position.x && EnemyAgent.transform.position.z == currentPivot.position.z)
        {
            UpdatePivot();
        }
    }
}
