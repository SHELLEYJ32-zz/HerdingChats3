using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeBonusController : MonoBehaviour
{

    public Text TimeBonus;

    void Start()
    {
        if (Global.Instance.endGame)
            TimeBonus.text = "Time Bonus: " + Mathf.RoundToInt(Global.Instance.RemainingTime * Global.Instance.timePointWorth);
    }


    public void FixedUpdate()
    {
        if (Global.Instance.endGame)
        {
            TimeBonus.text = "Time Bonus: " + Mathf.RoundToInt(Global.Instance.RemainingTime * Global.Instance.timePointWorth);
        }
    }

}
