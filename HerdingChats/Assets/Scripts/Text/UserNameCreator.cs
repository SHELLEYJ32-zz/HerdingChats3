using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserNameCreator : MonoBehaviour
{

    public Text userNameDisplay;
    private float fadeTimer;
    private Rigidbody2D rb;

    void Start()
    {
        fadeTimer = Global.Instance.userNameFadeTimer;
        rb = gameObject.GetComponent<Rigidbody2D>();
        Impulse();
    }

    public void Name(string userName)
    {
        Debug.Log(userName);
        userNameDisplay.text = userName;
        gameObject.GetComponentInChildren<Canvas>().worldCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        fadeTimer = fadeTimer - Time.deltaTime;
        if (fadeTimer <= 0.0f)
        {
            Destroy(gameObject);
        }
    }

    void Impulse()
    {
        Vector3 force = new Vector3(0, 200, 0);
        rb.AddForce(force);
    }
}
