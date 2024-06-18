using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float distancia = 300f;
    public TextMeshProUGUI textMeshPro;
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
