using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum PlayerState { Normal, Invisible, Ghost}

public class PlayerController : MonoBehaviour
{
    [SerializeField] private MaterialFloatController InDissolveController;
    [SerializeField] private MaterialFloatController OutDissolveController;

    [SerializeField] private PlayerState currentState = PlayerState.Normal;

    private MeshRenderer _meshRenderer;

    public PlayerState CurrentState => currentState;

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
        else if (other.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("Derrota");
        }else if (other.CompareTag("Victoria"))
        {
            SceneManager.LoadScene("Victoria");
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
