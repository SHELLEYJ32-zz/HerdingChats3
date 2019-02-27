using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatScoreController : MonoBehaviour
{
    public Text CatScoreText;

    void Start()
    {
        CatScoreText.text = "Final Score: " + Global.Instance.catScore;
    }


    public void FixedUpdate()
    {
        CatScoreText.text = "Final Score: " + Global.Instance.catScore;
    }

}
