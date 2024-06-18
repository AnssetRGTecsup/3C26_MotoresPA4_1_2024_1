using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject DummyGO;
    [SerializeField] private Vector3 _WorldPosition;

    public float distancia = 300f;
    public TextMeshProUGUI textMeshPro;
    private void Awake()
    {
        Instantiate(DummyGO, _WorldPosition, Quaternion.identity);

    }
    private void Update()
    {
        distancia -= Time.deltaTime;
        textMeshPro.text = "Tiempo: " + distancia.ToString("F0") ;
        if (distancia <= 0)
        {
            SceneManager.LoadScene("Derrota");
        }
    }
}
