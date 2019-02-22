using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SpriteRenderOrderController : MonoBehaviour
{

    void FixedUpdate()
    {
        SpriteRenderer[] spriteRenderers = FindObjectsOfType<SpriteRenderer>();
        TilemapRenderer tilemapRenderers = FindObjectOfType<TilemapRenderer>();

        foreach (SpriteRenderer renderer in spriteRenderers)
        {
            renderer.sortingOrder = (int)(renderer.transform.position.y * -10);
        }

        tilemapRenderers.sortingOrder = (int)(tilemapRenderers.transform.position.y * -10);

    }
}
