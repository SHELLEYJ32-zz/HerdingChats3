using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public Text Timertext;

    void Start()
    {
        Timertext.text = "Time Left: " + Mathf.RoundToInt(Global.Instance.timer) + " seconds";
    }


    public void FixedUpdate()
    {
        if (!Global.Instance.endGame && Mathf.RoundToInt(Global.Instance.timer - Time.deltaTime) >= 0)
        {
            Global.Instance.timer -= Time.deltaTime;
            Timertext.text = "Time Left: " + Mathf.RoundToInt(Global.Instance.timer) + " seconds";
        }
        else
        {
            Timertext.text = "Time Left: 0 seconds";
            Global.Instance.endGame = true;
        }
    }
}
