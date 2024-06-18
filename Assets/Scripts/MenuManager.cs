using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public RectTransform uiElement;
    public float moveDuration = 1f;
    public Vector2 targetPosition;
    public Vector2 targetScale;

    void Start()
    {

        uiElement.DOAnchorPos(targetPosition, moveDuration);


        uiElement.DOScale(targetScale, moveDuration);
    }
    public void SceneChange()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Inicio");
    }
}
