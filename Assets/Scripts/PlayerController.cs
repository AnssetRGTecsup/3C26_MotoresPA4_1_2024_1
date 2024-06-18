using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Unity.AI.Navigation;
public enum PlayerState { Normal, Invisible, Ghost}

public class PlayerController : MonoBehaviour
{
    [SerializeField] private MaterialFloatController InDissolveController;
    [SerializeField] private MaterialFloatController OutDissolveController;


    [SerializeField] private MaterialFloatController Ghost;
    [SerializeField] private MaterialFloatController OutGhost;
    [SerializeField] private NavMeshSurface navMesh;


    [SerializeField] private CapsuleCollider _playerCap;


    [SerializeField] private PlayerState currentState = PlayerState.Normal;

    private MeshRenderer _meshRenderer;

    public PlayerState CurrentState => currentState;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }
    private void Update()
    {
        if (currentState== PlayerState.Invisible)
        {
            _playerCap.enabled = false;
        }
        else if (currentState == PlayerState.Ghost)
        {
            navMesh.agentTypeID = 1;
           // navMesh.ignoreNavMeshObstacle = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("InDissolve"))
        {
            InDissolveController.UpdateFloatTween(_meshRenderer);
            currentState = PlayerState.Invisible;
        }
        else if (other.CompareTag("Ghost"))
        {
            Ghost.UpdateFloatTween(_meshRenderer);
            currentState = PlayerState.Ghost;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("InDissolve"))
        {
            OutDissolveController.UpdateFloatTween(_meshRenderer);
            currentState = PlayerState.Normal;
        }
         else if (other.CompareTag("Ghost"))
        {
            OutGhost.UpdateFloatTween(_meshRenderer);
            currentState = PlayerState.Normal;
        }

    }
}
