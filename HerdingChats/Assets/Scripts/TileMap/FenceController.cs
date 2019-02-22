﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceController : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Cat")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<PolygonCollider2D>(), gameObject.GetComponent<Collider2D>(), true);
        }

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Cat")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<PolygonCollider2D>(), gameObject.GetComponent<Collider2D>(), false);
        }
    }
}
