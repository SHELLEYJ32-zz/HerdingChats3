using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserNameCreator : MonoBehaviour
{

    public Text userNameDisplay;
    private float fadeTimer;

    void Start()
    {
        fadeTimer = Global.Instance.userNameFadeTimer;
    }

    public void Name(string userName, Camera camera)
    {
        Debug.Log(userName);
        userNameDisplay.text = userName;
        gameObject.GetComponentInChildren<Canvas>().worldCamera = camera;
    }

    private void Update()
    {
        fadeTimer = fadeTimer - Time.deltaTime;
        if (fadeTimer <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
