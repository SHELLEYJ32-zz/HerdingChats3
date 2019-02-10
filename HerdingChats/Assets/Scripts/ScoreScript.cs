using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text ScoreText;

    void Start()
    {
        ScoreText.text = "Score: " + Global.Instance.score;
    }


    public void FixedUpdate()
    {
        ScoreText.text = "Score: " + Global.Instance.score;
    }

}
