using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Global : MonoBehaviour
{

    public static Global Instance; //Creates a new instance if one does not yet exist

    //Tweakables
    public float playerSpeed = 5.0f;
    public float playerSlowSpeed = 1.0f;
    public float catMoveForce = 500.0f;
    public float catMoveTimeMax = 10.0f;
    public float catMoveTimeMin = 1.0f;
    public float catEvadeSpeed = 7.0f;
    public float catDriftSpeed = 2.0f;
    public float catEvadeCooldown = 0.5f;
    public float catPostMoveTimer = 5.0f;
    public float netTimer = 0.5f;
    public int catRayNumber = 8;

    //scores
    public int catPointWorth = 10;
    public int timePointWorth = 10;
    public int catComboTimer = 2;
    public int score;

    //Toggles
    public bool streamerMode = true;

    //End Game
    public bool endGame;

    //Counters
    public int catsCaught;
    public float timer = 90f;
    public float previousCatCaughtTime;
    public float latterCatCaughtTime;
    public float CatCaughtTimeInterval;

    //position
    public bool playerInRiver;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject); //makes instance persist across scenes
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject); //deletes copies of global which do not need to exist, so right version is used to get info from
        }
    }

    public void CheckEndGame()
    {
        if (System.Math.Abs(timer - 0) < Mathf.Epsilon)
            endGame = true;
        if (endGame)
            SceneManager.LoadScene(sceneName: "EndScene");
    }

}
