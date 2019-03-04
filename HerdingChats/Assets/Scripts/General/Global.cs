using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Global : MonoBehaviour
{
    //this class is accesspible frm anywhere in the game, and holds all of the games global variables

    public static Global Instance; //Creates a new instance if one does not yet exist

    //Tweakables
    public float playerSpeed = 10.0f;
    public float playerSlowSpeed = 3.0f;
    public float catMoveForce = 500.0f;
    public float catMoveTimeMax = 10.0f;
    public float catMoveTimeMin = 1.0f;
    public float catEvadeSpeed = 12.0f;
    public float catDriftSpeed = 2.0f;
    public float catEvadeCooldown = 0.5f;
    public float catPostMoveTimer = 5.0f;
    public float netTimer = 0.5f;
    public float iceTimer = 10.0f;
    public int catTotalNumber = 20;
    public int catPowerNumber = 2;
    public float playerSlideMultiplier = 5.0f;
    public float catMeowMinGap = 10.0f;
    public float catMeowMaxGap = 30.0f;
    public float userNameFadeTimer = 1.0f;

    //Options
    public string twitchName = null;

    //scores
    public int catPointWorth = 10;
    public int timePointWorth = 10;
    public int catComboTimer = 2;
    public int catScore;
    public int finalScore;

    //Toggles
    public bool streamerMode = true;
    public string playerMoveMode = "Walk";

    //End Game
    public bool endGame;

    //Counters
    public int catsCaught;
    public float timer = 180.0f;
    public float RemainingTime;
    public float previousCatCaughtTime;
    public float latterCatCaughtTime;
    public float CatCaughtTimeInterval;

    //state
    public bool playerStill;
    public bool playerInRiver;
    public bool playerNewIceCat;

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

    public void CheckEndGame() //if the game timer reaches zero, end the game
    {
        if (System.Math.Abs(timer - 0) < Mathf.Epsilon)
            endGame = true;
        if (endGame) //can be triggered by cathing all of the cats
            SceneManager.LoadScene(sceneName: "EndScene");
    }

}
