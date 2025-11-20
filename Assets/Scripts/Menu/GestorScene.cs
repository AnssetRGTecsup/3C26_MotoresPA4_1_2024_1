using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorScene : MonoBehaviour
{
    private void OnEnable()
    {
        SceneEvents.OnJugar += LoadGame;
        SceneEvents.OnVolverMenu += LoadMenu;
        SceneEvents.OnGameOver += LoadGameOver;
        SceneEvents.OnExitTheGame += Saliendo;
    }
    private void OnDisable()
    {
        SceneEvents.OnJugar -= LoadGame;
        SceneEvents.OnVolverMenu -= LoadMenu;
        SceneEvents.OnGameOver -= LoadGameOver;
        SceneEvents.OnExitTheGame += Saliendo;
    }

    void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    void Saliendo()
    {
        Application.Quit();
        Debug.Log("tesaliste");
    }
}
