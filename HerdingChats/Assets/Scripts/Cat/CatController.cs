using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{   //This isn't the script which controlls individual cat movement. Rather, it is the script that chooses a cat to move, 
    //and then sends the command to move to a script on the cat object.


    private GameObject selectedCat;
    private new Camera camera;

    void Start()
    {
        camera = FindObjectOfType<Camera>().GetComponent<Camera>(); //get the camera so we can check if cats are on screen
    }

    public void ChatMoveCommand(string direction, string user)
    {
        GameObject[] cats;
        int r;
        cats = GameObject.FindGameObjectsWithTag("Cat"); //Get an array of all the cats in the level


        List<GameObject> catsOnCamera = new List<GameObject>(); //Create list for tracking which cats are on camera

        for (int i = 0; i < cats.Length; i++) //for each cat, check if it is on the screen
        {
            if (cats[i].transform.position.x > camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x && cats[i].transform.position.x < camera.ViewportToWorldPoint(new Vector3(1, 1, 0)).x)
                if (cats[i].transform.position.y > camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y && cats[i].transform.position.y < camera.ViewportToWorldPoint(new Vector3(1, 1, 0)).y)
                    catsOnCamera.Add(cats[i]); //if it is, add it to the list
        }
        if (catsOnCamera.Count == 0) //if no cats on camera, send command to random cat
        {
            r = Random.Range(0, cats.Length);
            selectedCat = cats[r];
            selectedCat.GetComponent<Cat>().Move(direction, user);
            selectedCat.GetComponent<Cat>().ChangeSprite();
            //Debug.Log("Cat " + selectedCat + " Moved");
        }
        else //send command to a cat that is on camera
        {
            r = Random.Range(0, catsOnCamera.Count);
            selectedCat = catsOnCamera[r];
            selectedCat.GetComponent<Cat>().Move(direction, user);
            selectedCat.GetComponent<Cat>().ChangeSprite();
            //Debug.Log("Cat " + selectedCat + " Moved");
        }
    }
}
