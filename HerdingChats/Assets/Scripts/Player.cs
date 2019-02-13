using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D playerRB;
    public GameObject net;
    private bool netFlag;
    private float netTimer;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        netTimer = Global.Instance.netTimer;
    }

    void FixedUpdate()
    {
        Global.Instance.CheckEndGame();
        Vector3 movement = Vector3.zero;
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        movement = Vector3.ClampMagnitude(movement, 1.0f);
        playerRB.velocity = movement * Global.Instance.playerSpeed;

        if (Input.GetKeyDown(KeyCode.F))
        {
            netSwipe();
            netFlag = true;
        }

        if (netFlag == true)
        {
            netTimer = netTimer - Time.deltaTime;
            if (netTimer <= 0.0f)
            {
                netTimer = Global.Instance.netTimer;
                Destroy(GameObject.FindGameObjectWithTag("Net"));
                netFlag = false;
            }
        }
    }

    void netSwipe()
    {
        Vector3 netPosition = gameObject.transform.position;
        GameObject newNet = Instantiate(net, netPosition, Quaternion.identity);
        newNet.transform.SetParent(gameObject.transform);
    }




}
