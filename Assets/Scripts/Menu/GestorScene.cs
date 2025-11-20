using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorScene : MonoBehaviour
{
    private void OnEnable()
    {
        SceneEvents.OnJugar += LoadGame;
        SceneEvents.OnVolverMenu += LoadMenu;
        SceneEvents.OnGameOver += LoadGameOver;
    }
    private void OnDisable()
    {
        SceneEvents.OnJugar -= LoadGame;
        SceneEvents.OnVolverMenu -= LoadMenu;
        SceneEvents.OnGameOver -= LoadGameOver;
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
}
