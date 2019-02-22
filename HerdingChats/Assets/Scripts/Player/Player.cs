using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRB;
    //public GameObject net;
    private float iceTimer;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        iceTimer = Global.Instance.iceTimer;
        Global.Instance.playerMoveMode = "Walk";
        Global.Instance.playerInRiver = false;
    }

    void FixedUpdate()
    {
        Global.Instance.CheckEndGame();
        Vector3 movement = Vector3.zero;
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        movement = Vector3.ClampMagnitude(movement, 1.0f);

        if (Global.Instance.playerMoveMode == "Walk")
        {
            walk(movement);
        }
        else if (Global.Instance.playerMoveMode == "Slide")
        {
            glide(movement);
            iceTimer = iceTimer - Time.deltaTime;
            if (iceTimer <= 0.0f)
            {
                iceTimer = Global.Instance.iceTimer;
                Global.Instance.playerMoveMode = "Walk";
            }
        }

        //if (Input.GetKeyDown(KeyCode.F))
        //{
        //    netSwipe();
        //}
    }

    void walk(Vector3 movement)
    {
        if (!Global.Instance.playerInRiver)
        {
            playerRB.velocity = movement * Global.Instance.playerSpeed;
        }
        else
        {
            playerRB.velocity = movement * Global.Instance.playerSlowSpeed;
        }
    }

    void glide(Vector3 movement)
    {
        if (!Global.Instance.playerInRiver)
        {
            playerRB.AddForce((movement * Global.Instance.playerSpeed) * Global.Instance.playerSlideMultiplier);
        }
        else
        {
            playerRB.AddForce((movement * Global.Instance.playerSlowSpeed) * Global.Instance.playerSlideMultiplier);
        }
    }

    //void netSwipe()
    //{
    //    Vector3 netPosition = gameObject.transform.position;
    //    GameObject newNet = Instantiate(net, netPosition, Quaternion.identity);
    //    newNet.transform.SetParent(gameObject.transform);
    //}


}
