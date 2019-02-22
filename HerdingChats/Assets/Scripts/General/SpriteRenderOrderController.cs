using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRenderOrderController : MonoBehaviour
{

    void FixedUpdate()
    {
        SpriteRenderer[] renderers = FindObjectsOfType<SpriteRenderer>();

        foreach (SpriteRenderer renderer in renderers)
        {
            renderer.sortingOrder = (int)(renderer.transform.position.y * -10);
        }

    }
}
