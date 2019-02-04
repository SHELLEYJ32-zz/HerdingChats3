using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    public GameObject player, background;

    void Start()
    {
        transform.position = new Vector3(background.transform.position.x, background.transform.position.y, 0);
    }

    void Update()
    {

        if (Approximately(transform.position.x, player.transform.position.x, 0.1f))
        {
            transform.position = new Vector3(player.transform.position.x, transform.position.y, 0);
        }
        if (Approximately(transform.position.y, player.transform.position.y, 0.1f))
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y, 0);
        }

    }

    bool Approximately(float a, float b, float threshold)
    {
        return System.Math.Abs(a - b) <= threshold;
    }
}