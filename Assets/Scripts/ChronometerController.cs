using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;    

public class ChronometerController : MonoBehaviour
{
    [SerializeField] private TMP_Text chronometerText;

    private float timeElapsed;
    private int minutes;
    private int seconds;

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        minutes = (int)(timeElapsed / 60f);
        seconds = (int)(timeElapsed - minutes * 60f);

        chronometerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void DefeatGame()
    {
        if (seconds == 05)
        {
            SceneManager.LoadScene("DefeatScene");
        }
    }
}