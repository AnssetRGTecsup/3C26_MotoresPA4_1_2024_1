using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState { Normal, Invisible, Ghost}

public class PlayerController : MonoBehaviour
{
    [SerializeField] private MaterialFloatController InDissolveController;
    [SerializeField] private MaterialFloatController OutDissolveController;

    [SerializeField] private PlayerState currentState = PlayerState.Normal;

    private MeshRenderer _meshRenderer;

    public PlayerState CurrentState => currentState;

    [SerializeField] private ObjectivesController objectives;

    private bool greenCube;
    private bool blueSphere;

    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("InDissolve"))
        {
            InDissolveController.UpdateFloatTween(_meshRenderer);
        }
        else if (other.CompareTag("GreenCube"))
        {
            objectives.CompleteObjective(0);
            greenCube = true;
        }
        else if (other.CompareTag("BlueSphere"))
        {
            objectives.CompleteObjective(1);
            blueSphere = true;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Win"))
        {
            if (greenCube == true && blueSphere == true)
            {
                GameManagerController.Instance.LoadScene("Win");
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("InDissolve"))
        {
            OutDissolveController.UpdateFloatTween(_meshRenderer);
        }
    }
}
