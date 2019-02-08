using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public Text ScoreText;

    void Start()
    {
        ScoreText.text = "Score: 0";
    }


    public void UpdateScore()
    {

    }
}
