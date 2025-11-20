using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class MousPosition : MonoBehaviour
{
    [SerializeField] private GameObject DummyGO;
    [SerializeField] private Vector2 _position;
    [SerializeField] private Vector3 _WorldPosition;
    [SerializeField] private NavMeshAgent agent;

    private bool isMoving;
    public void OnMovement(InputAction.CallbackContext context)
    {
        _position = context.ReadValue<Vector2>();
    }

    public void RightOnClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Clicked");

            Ray camRay = Camera.main.ScreenPointToRay(_position);

            if (Physics.Raycast(camRay, out RaycastHit hit))
            {
                Debug.Log("Raycast shot");

                _WorldPosition = hit.point;

                Instantiate(DummyGO, _WorldPosition, Quaternion.identity);
                isMoving = false;
                agent.ResetPath();
            }
        }
    }

    public void LeftOnClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Clicked");

            Ray camRay = Camera.main.ScreenPointToRay(_position);

            if (Physics.Raycast(camRay, out RaycastHit hit))
            {
                Debug.Log("Raycast shot");

                _WorldPosition = hit.point;

                agent.SetDestination(_WorldPosition);
                isMoving=true;
            }
        }
    }
}
