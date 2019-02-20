using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public Text TimerText;
    private string minutes;
    private string seconds;

    void Start()
    {
        minutes = Mathf.Floor(Global.Instance.timer / 60).ToString("00");
        seconds = Mathf.RoundToInt(Global.Instance.timer % 60).ToString("00");

        TimerText.text = "Time Left: " + minutes + " : " + seconds;
    }


    public void FixedUpdate()
    {
        if (!Global.Instance.endGame)
        {
            if (Mathf.RoundToInt(Global.Instance.timer - Time.deltaTime) >= 0)
            {
                Global.Instance.timer -= Time.deltaTime;
                minutes = Mathf.Floor(Global.Instance.timer / 60).ToString("00");
                seconds = Mathf.RoundToInt(Global.Instance.timer % 60).ToString("00");
                TimerText.text = "Time Left: " + minutes + " : " + seconds;
            }

            else
            {
                TimerText.text = "Time Left: 00:00";
                Global.Instance.timer = 0;
                Global.Instance.endGame = true;
            }
        }
    }

}
