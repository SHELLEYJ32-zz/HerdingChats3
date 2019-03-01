using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cat : MonoBehaviour
{
    public Sprite TwitchChongus;

    private Rigidbody2D catRB;
    private Sprite originalSprite;
    private GameObject TwitchName;
    private AudioClip meowChoice;


    //Audio
    public AudioClip meow1;
    public AudioClip meow2;
    public AudioClip meow3;

    //move and drift
    private float moveHorizontal;
    private float moveVertical;
    private float driftHorizontal;
    private float driftVertical;
    private float catMoveTimer;
    private float catDriftTimer;
    private float catMoveChance;
    private float catDriftChance;
    private float catMoveDirectionChance;
    private float catDriftDirectionChance;
    private string catMoveDirection;

    private Vector3 drift;
    private Vector3 away;

    //evade
    private float localCatEvadeCooldown;
    private float catPostMoveTimer;
    private bool evadeFlag;
    private bool postMoveFlag;

    private int catCount;
    private float catSoundTimer;

    //caught
    private float catCaughtRotationSpeed;
    private float catDisappearTimer;
    private bool catCaughtFlag;
    private bool catDestroyFlag;


    void Start()
    {
        catRB = gameObject.GetComponent<Rigidbody2D>(); //Get the cats Rigidbody2D
        originalSprite = gameObject.GetComponent<SpriteRenderer>().sprite; //Save the sprite the cat spawned with so we can change it back later
        catMoveTimer = 0.0f; //set cat move timer
        catMoveDirectionChance = Random.Range(Global.Instance.catMoveTimeMin, Global.Instance.catMoveTimeMax); //set an initial random value for the cats move direction
        catMoveChance = Random.Range(Global.Instance.catMoveTimeMin, Global.Instance.catMoveTimeMax); //set an initial random value for the cats chance to move
        catDriftChance = Random.Range(Global.Instance.catMoveTimeMin, Global.Instance.catMoveTimeMax); //set an initial random value for the cats chance to change drift direction
        localCatEvadeCooldown = Global.Instance.catEvadeCooldown; //set the cats evade cooldown
        catPostMoveTimer = Global.Instance.catPostMoveTimer; // set the length of time the cat will idle after moving
        drift = Vector3.zero; //initialize empty Vectors for drift and evasion
        away = Vector3.zero;
        DriftDirection(); //Start the cat drifting
        GameObject[] catArray = GameObject.FindGameObjectsWithTag("Cat"); //get array of all cats in scene
        catCount = catArray.Length; //count them for later
        catSoundTimer = Random.Range(Global.Instance.catMeowMinGap, Global.Instance.catMeowMaxGap); //set initial random value for time to meow
        catCaughtRotationSpeed = 20.0f; //set speed for cought spin
        catDisappearTimer = 0.4f; //set time for cat to kepp spinning
        TwitchName = Resources.Load("TwitchName") as GameObject; //ready the prefab to display twitch users names
    }

    void FixedUpdate()
    {
        catMoveTimer += Time.deltaTime; //Increment all timers
        catDriftTimer += Time.deltaTime;
        catSoundTimer -= Time.deltaTime;

        if (!Global.Instance.streamerMode)
        {
            if (catMoveTimer >= catMoveChance)
            {
                AutoMove();
            }
        }

        if (evadeFlag)
        {
            catRB.velocity = Global.Instance.catEvadeSpeed * drift;
            localCatEvadeCooldown = localCatEvadeCooldown - Time.deltaTime;

        }
        else if (!evadeFlag && !postMoveFlag)
        {
            catRB.velocity = Global.Instance.catDriftSpeed * drift;
        }

        if (postMoveFlag)
        {
            catPostMoveTimer = catPostMoveTimer - Time.deltaTime;
            if (catPostMoveTimer <= 0.0f)
            {
                postMoveFlag = false;
                catPostMoveTimer = Global.Instance.catPostMoveTimer;
                gameObject.GetComponent<SpriteRenderer>().sprite = originalSprite;
            }
        }

        if (localCatEvadeCooldown <= 0.0f)
        {
            evadeFlag = false;
            localCatEvadeCooldown = Global.Instance.catEvadeCooldown;
            //Debug.Log("Stop Evading");
        }

        if (catDriftTimer >= catDriftChance && evadeFlag == false)
        {
            DriftDirection();
            //Debug.Log("Drift direction changed");
        }

        if (catSoundTimer <= 0.0f)
        {
            CatSound();
            catSoundTimer = Random.Range(Global.Instance.catMeowMinGap, Global.Instance.catMeowMaxGap);
        }

        if (catCaughtFlag)
        {
            if (gameObject.GetComponent<PolygonCollider2D>().enabled)
            {
                gameObject.GetComponent<PolygonCollider2D>().enabled = false;
            }
            gameObject.transform.Rotate(0, 0, catCaughtRotationSpeed);

            if (catDisappearTimer - Time.deltaTime >= 0)
            {
                catDisappearTimer -= Time.deltaTime;
            }
            else
            {
                catDestroyFlag = true;
            }
        }

        if (catDestroyFlag)
        {
            Destroy(gameObject);
        }
    }

    public void Move(string direction, string userName = "None")
    {
        //Debug.Log("Cat " + gameObject + " moved " + direction + "!");
        if (direction == "!Up" || direction == "!up" || direction == "!u")
        {
            moveHorizontal = 0.0f;
            moveVertical = Global.Instance.catMoveForce;
        }
        else if (direction == "!Down" || direction == "!down" || direction == "!d")
        {
            moveHorizontal = 0.0f;
            moveVertical = -Global.Instance.catMoveForce;
        }
        else if (direction == "!Left" || direction == "!left" || direction == "!l")
        {
            moveHorizontal = -Global.Instance.catMoveForce;
            moveVertical = 0.0f;
        }
        else if (direction == "!Right" || direction == "!right" || direction == "!r")
        {
            moveHorizontal = Global.Instance.catMoveForce;
            moveVertical = 0.0f;
        }

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        catRB.AddForce(movement);
        if (Global.Instance.streamerMode)
        {
            UserNameDisplay(userName);
        }
        postMoveFlag = true;
    }

    void DriftDirection()
    {
        //Debug.Log("Cat " + gameObject + " changed drift direction!");
        //Will cause cats to slowly move around
        catDriftDirectionChance = Random.Range(1, 100);
        if (catDriftDirectionChance <= 25)
        {
            //driftHorizontal = 0.0f;
            driftVertical = Global.Instance.catDriftSpeed;
            driftVertical = Global.Instance.catMoveForce;
        }
        else if (catDriftDirectionChance > 25 && catDriftDirectionChance <= 50)
        {
            //driftHorizontal = 0.0f;
            driftVertical = -Global.Instance.catDriftSpeed;
            driftVertical = Global.Instance.catMoveForce;
        }
        else if (catDriftDirectionChance > 50 && catDriftDirectionChance <= 75)
        {
            driftHorizontal = -Global.Instance.catDriftSpeed;
            //driftHorizontal = Global.Instance.catMoveForce;
            driftVertical = 0.0f;
        }
        else if (catDriftDirectionChance > 75 && catDriftDirectionChance <= 100)
        {
            driftHorizontal = Global.Instance.catDriftSpeed;
            //driftHorizontal = Global.Instance.catMoveForce;
            driftVertical = 0.0f;
        }
        drift.x = driftHorizontal;
        drift.y = driftVertical;
        drift = Vector3.ClampMagnitude(drift, 1.0f);
        catRB.velocity = drift * Global.Instance.catDriftSpeed;
        //catRB.AddForce(drift);
        catDriftTimer = 0.0f;
    }

    void AutoMove()
    {
        if (catMoveTimer >= catMoveChance)
        {
            catMoveDirectionChance = Random.Range(1, 100);
            if (catMoveDirectionChance <= 25)
            {
                catMoveDirection = "Up";
            }
            else if (catMoveDirectionChance > 25 && catMoveDirectionChance <= 50)
            {
                catMoveDirection = "Down";
            }
            else if (catMoveDirectionChance > 50 && catMoveDirectionChance <= 75)
            {
                catMoveDirection = "Left";
            }
            else if (catMoveDirectionChance > 75 && catMoveDirectionChance <= 100)
            {
                catMoveDirection = "Right";
            }
            Move(catMoveDirection);
            catMoveChance = Random.Range(Global.Instance.catMoveTimeMin, Global.Instance.catMoveTimeMax);
            catMoveTimer = 0.0f;
            postMoveFlag = true;
        }
    }

    void Evade(Collider2D collider)
    {
        //Debug.Log(gameObject + "Evading");
        drift = gameObject.transform.position - collider.gameObject.transform.position;
        drift = Vector3.ClampMagnitude(drift, 1.0f);
        catRB.velocity = drift * Global.Instance.catEvadeSpeed;
    }

    void MoveAway(Collision2D collision)
    {
        Vector2 contactPoint = collision.GetContact(0).point;
        Vector3 localAway = new Vector3(contactPoint.x, contactPoint.y, 0.0f);
        drift = gameObject.transform.position - localAway;

    }

    void CatCaught(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !catCaughtFlag)
        {
            CatSound();
            catCaughtFlag = true;
            Global.Instance.catsCaught = Global.Instance.catsCaught + 1;
            if (System.Math.Abs(Global.Instance.previousCatCaughtTime - 0f) < Mathf.Epsilon)
            {
                Global.Instance.previousCatCaughtTime = Time.time;
            }
            else
            {
                Global.Instance.latterCatCaughtTime = Time.time;
                Global.Instance.CatCaughtTimeInterval = Global.Instance.latterCatCaughtTime - Global.Instance.previousCatCaughtTime;
                Global.Instance.previousCatCaughtTime = Global.Instance.latterCatCaughtTime;
            }
            if (Global.Instance.catsCaught != 1 && Global.Instance.CatCaughtTimeInterval <= Global.Instance.catComboTimer)
                Global.Instance.catScore += Global.Instance.catPointWorth * 2;
            else
                Global.Instance.catScore += Global.Instance.catPointWorth;

            //Debug.Log(Global.Instance.catsCaught);
            if (gameObject.GetComponent<SpriteRenderer>().sprite.name == "Ice_Chongus")
            {
                Global.Instance.playerNewIceCat = true;
            }

            if (Global.Instance.catsCaught == catCount)
            {
                Global.Instance.endGame = true;
            }

        }
    }


    public void ChangeSprite()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = TwitchChongus;
    }

    public void UserNameDisplay(string userName)
    {
        GameObject newName = Instantiate(TwitchName);
        newName.transform.position = gameObject.transform.position;
        newName.GetComponent<UserNameCreator>().Name(userName);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != 10 || collision.gameObject.layer != 12)
        {
            MoveAway(collision);
        }
        else if (collision.gameObject.layer == 10)
        {
            CatCaught(collision);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("Trigger fired on " + collider.gameObject);
        if (collider.gameObject.tag == "Player")
        {
            evadeFlag = true;
            Evade(collider);
        }
    }

    void CatSound()
    {
        float randomMeow = Random.Range(0.0f, 3.0f);
        if (randomMeow < 1.0f)
        {
            meowChoice = meow1;
        }
        else if (randomMeow >= 1.0f && randomMeow < 2.0f)
        {
            meowChoice = meow2;
        }
        else if (randomMeow > 2.0f)
        {
            meowChoice = meow3;
        }
        gameObject.GetComponent<AudioSource>().clip = meowChoice;
        gameObject.GetComponent<AudioSource>().Play();
    }
}
