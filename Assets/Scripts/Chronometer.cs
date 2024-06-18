using UnityEngine;
using TMPro;
public class Chronometer : MonoBehaviour
{
    [SerializeField] private TMP_Text timer;
    [SerializeField] private float minutes;
    [SerializeField] private float seconds;
    private void Update()
    {
        if(seconds < 0)
        {
            seconds = 60;
            minutes = minutes - 1;
        }
        if(minutes < 0)
        {
            GameManagerController.Instance.LoadScene("GameOver");
        }
        seconds = seconds - Time.deltaTime;
        SetTimerTime();
    }
    private void SetTimerTime()
    {
        timer.text = minutes.ToString("0") + ":" + seconds.ToString("f0");
    }

}
