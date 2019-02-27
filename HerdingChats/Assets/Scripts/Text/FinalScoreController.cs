using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreController : MonoBehaviour
{
    public Text FinalScoreText;

    void Start()
    {
        if (Global.Instance.endGame)
        {
            Global.Instance.finalScore = Global.Instance.catScore + Mathf.RoundToInt(Global.Instance.RemainingTime * Global.Instance.timePointWorth);
            FinalScoreText.text = "Final Score: " + Global.Instance.finalScore;
        }
    }


    public void FixedUpdate()
    {
        if (Global.Instance.endGame)
        {
            Global.Instance.finalScore = Global.Instance.catScore + Mathf.RoundToInt(Global.Instance.RemainingTime * Global.Instance.timePointWorth);
            FinalScoreText.text = "Final Score: " + Global.Instance.finalScore;
        }
    }

}
