using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceController : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        //ignore collision of box collider and cats to allow them pass
        if (collision.gameObject.tag == "Cat")
        {
            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<PolygonCollider2D>(), gameObject.GetComponent<BoxCollider2D>(), true);
        }

    }

}
