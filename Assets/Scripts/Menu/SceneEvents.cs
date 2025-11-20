using System;
using UnityEngine;

public class SceneEvents : MonoBehaviour
{
    public static event Action OnJugar;
    public static event Action OnVolverMenu;
    public static event Action OnGameOver;

    public static void Jugar()
    {
        OnJugar?.Invoke();
    }

    public static void volverMenu()
    {
        OnVolverMenu?.Invoke();
    }

    public static void GameOver()
    {
        OnGameOver?.Invoke();
    }

}
