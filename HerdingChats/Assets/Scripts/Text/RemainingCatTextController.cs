using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemainingCatTextController : MonoBehaviour
{
    public Text RemainingCatText;

    void Start()
    {
        RemainingCatText.text = "Cats Left: " + (Global.Instance.catTotalNumber - Global.Instance.catsCaught);
    }


    public void FixedUpdate()
    {
        RemainingCatText.text = "Cats Left: " + (Global.Instance.catTotalNumber - Global.Instance.catsCaught);
    }
}
