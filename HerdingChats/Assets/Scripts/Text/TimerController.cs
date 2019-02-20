using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public Text TimerText;
    private float localTimer;
    private string minutes;
    private string seconds;

    void Start()
    {
        localTimer = Global.Instance.timer;
        minutes = Mathf.Floor(localTimer / 60).ToString("00");
        seconds = Mathf.RoundToInt(localTimer % 60).ToString("00");

        TimerText.text = "Time Left: " + minutes + " : " + seconds;
    }


    public void FixedUpdate()
    {
        if (!Global.Instance.endGame)
        {
            if (localTimer - Time.deltaTime >= 0)
            {
                localTimer -= Time.deltaTime;
                //Debug.Log(localTimer);
                minutes = Mathf.Floor(localTimer / 60).ToString("00");
                seconds = Mathf.RoundToInt(localTimer % 60).ToString("00");
                TimerText.text = "Time Left: " + minutes + " : " + seconds;
            }

            else
            {
                TimerText.text = "Time Left: 00:00";
                Global.Instance.endGame = true;
            }
        }
    }

}
