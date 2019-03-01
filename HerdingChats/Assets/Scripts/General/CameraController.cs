using UnityEngine;
using System.Collections;


public class CameraController : MonoBehaviour
{
    public GameObject player;

    //camera centers the player
    void Start()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0);
    }

    //camera stays with the player
    void FixedUpdate()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0);
    }

}