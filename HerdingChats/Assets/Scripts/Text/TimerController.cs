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
        Global.Instance.RemainingTime = Global.Instance.timer;
        minutes = Mathf.Floor(Global.Instance.RemainingTime / 60).ToString("00");
        seconds = Mathf.RoundToInt(Global.Instance.RemainingTime % 60).ToString("00");

        TimerText.text = "Time Left: " + minutes + " : " + seconds;
    }


    public void FixedUpdate()
    {
        if (!Global.Instance.endGame)
        {
            if (Global.Instance.RemainingTime - Time.deltaTime >= 0)
            {
                Global.Instance.RemainingTime -= Time.deltaTime;
                //Debug.Log(localTimer);
                minutes = Mathf.Floor(Global.Instance.RemainingTime / 60).ToString("00");
                seconds = Mathf.RoundToInt(Global.Instance.RemainingTime % 60).ToString("00");
                TimerText.text = "Time Left: " + minutes + " : " + seconds;
            }

            else
            {
                Global.Instance.RemainingTime = 0;
                TimerText.text = "Time Left: 00:00";
                Global.Instance.endGame = true;
            }
        }
    }

}
