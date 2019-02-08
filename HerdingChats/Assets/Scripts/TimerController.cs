using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public Text TimerText;

    void Start()
    {
        TimerText.text = "Time Left: " + Mathf.RoundToInt(Global.Instance.timer) + " seconds";
    }


    public void FixedUpdate()
    {
        if (!Global.Instance.endGame)
        {
            if (Mathf.RoundToInt(Global.Instance.timer - Time.deltaTime) >= 0)
            {
                Global.Instance.timer -= Time.deltaTime;
                TimerText.text = "Time Left: " + Mathf.RoundToInt(Global.Instance.timer) + " seconds";
            }

            else
            {
                TimerText.text = "Time Left: 0 seconds";
                Global.Instance.timer = 0;
                Global.Instance.endGame = true;
            }
        }
    }

}
