﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRB;
    public GameObject net;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Global.Instance.CheckEndGame();
        Vector3 movement = Vector3.zero;
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        movement = Vector3.ClampMagnitude(movement, 1.0f);
        if (!Global.Instance.playerInRiver)
        {
            playerRB.velocity = movement * Global.Instance.playerSpeed;
        }
        else
        {
            playerRB.velocity = movement * Global.Instance.playerSlowSpeed;
        }


        if (Input.GetKeyDown(KeyCode.F))
        {
            netSwipe();
        }
    }

    void netSwipe()
    {
        Vector3 netPosition = gameObject.transform.position;
        GameObject newNet = Instantiate(net, netPosition, Quaternion.identity);
        newNet.transform.SetParent(gameObject.transform);
    }


}
