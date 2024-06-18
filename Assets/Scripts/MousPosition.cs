using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class MousePosition : MonoBehaviour
{
    [SerializeField] private Vector2 _position;
    [SerializeField] private Vector3 _WorldPosition;
    [SerializeField] private NavMeshAgent agent;
    public void OnMovement(InputAction.CallbackContext context)
    {
        _position = context.ReadValue<Vector2>();
    }
    public void RightOnClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            agent.isStopped = true;
        }
    }
    public void LeftOnClick(InputAction.CallbackContext context)
    {
        agent.isStopped = false;
        if (context.performed)
        {
            Ray camRay = Camera.main.ScreenPointToRay(_position);

            if (Physics.Raycast(camRay, out RaycastHit hit))
            {
                _WorldPosition = hit.point;
                agent.SetDestination(_WorldPosition);
            }
        }
    }
}
