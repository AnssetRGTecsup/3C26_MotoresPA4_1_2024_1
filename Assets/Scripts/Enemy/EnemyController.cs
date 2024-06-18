using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private PlayerController playerReference;

    [SerializeField] NavMeshAgent EnemyAgent;

    [SerializeField] private List<Transform> PivotPositions;

    [SerializeField] private int pivotCounter = 0;
    [SerializeField] private int pivotPoints;
    [SerializeField] private int currentIndex;
    private Transform currentPivot;

    private void Awake()
    {
        pivotPoints = PivotPositions.Count - 1;
        currentIndex = 0;

        currentPivot = PivotPositions[currentIndex];
    }

    [ContextMenu("Add Counter")]
    private void UpdatePivot()
    {
        currentIndex = (int)Mathf.PingPong(++pivotCounter, pivotPoints);

        currentPivot = PivotPositions[currentIndex];

        EnemyAgent.SetDestination(currentPivot.position);   
    }
    /*�private void Update()
    {
       // UpdatePivot();
    }*/
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && playerReference.CurrentState == PlayerState.Normal)
        {
            EnemyAgent.SetDestination(other.transform.position);
            SceneManager.LoadScene("DefeatScene");
        }
        else if(other.CompareTag("Player") && playerReference.CurrentState == PlayerState.Invisible)
        {
            Debug.Log("invisible");
        }
        else if (other.CompareTag("Player") && playerReference.CurrentState == PlayerState.Ghost)
        {
            Debug.Log("no interact");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UpdatePivot();
        }
    }
}
