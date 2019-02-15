using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverController : MonoBehaviour
{
    //private Rigidbody2D riverRB;

    //void Start()
    //{
    //    riverRB = gameObject.GetComponent<Rigidbody2D>();
    //}


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Global.Instance.playerInRiver = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Global.Instance.playerInRiver = false;
        }
    }

}
