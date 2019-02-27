using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class CatGroupController : MonoBehaviour
{
    public GameObject catPrefab;
    public GameObject player;
    public Sprite Normal1;
    public Sprite Normal2;
    public Sprite Normal3;
    public Sprite Normal4;
    public Sprite Normal5;
    public Sprite IcePower;

    private GameObject[] catArray;
    private Sprite[] NormalSpriteArray;
    private Sprite[] PowerSpriteArray;


    // Start is called before the first frame update
    void Start()
    {
        catArray = new GameObject[Global.Instance.catTotalNumber];
        float catLength = catPrefab.GetComponent<Renderer>().bounds.size.x;
        float catPosStartX = player.transform.position.x - Global.Instance.catTotalNumber / 2 * catLength;
        float catHeight = catPrefab.GetComponent<Renderer>().bounds.size.y;
        float catPosStartY = player.transform.position.y - 3 * catHeight;
        NormalSpriteArray = new Sprite[] { Normal1, Normal2, Normal3, Normal4, Normal5 };
        PowerSpriteArray = new Sprite[] {IcePower};

        for (int i = 0; i < catArray.Length; i++)
        {
            Vector3 catPos = new Vector3(catPosStartX + i * catLength, catPosStartY, 0);
            catArray[i] = Instantiate(catPrefab, catPos, Quaternion.identity);
        }
        UseSprite();

    }

    void UseSprite()
    {
        int normalCatCount = 0;
        int powerCatCount = 0;

        for (int i = 0; i < catArray.Length; i++)
        {
            //randomly generate normal and power to the limited number
            if (normalCatCount < Global.Instance.catTotalNumber - Global.Instance.catPowerNumber & powerCatCount < Global.Instance.catPowerNumber)
            {
                int catPowerChance = Random.Range(0, Global.Instance.catTotalNumber);

                if (catPowerChance < Global.Instance.catPowerNumber)
                {
                    int spriteIndex = Random.Range(0, PowerSpriteArray.Length);
                    catArray[i].GetComponent<Cat>().GetComponent<SpriteRenderer>().sprite = PowerSpriteArray[spriteIndex];
                    powerCatCount++;
                }
                else
                {
                    int spriteIndex = Random.Range(0, NormalSpriteArray.Length);
                    catArray[i].GetComponent<Cat>().GetComponent<SpriteRenderer>().sprite = NormalSpriteArray[spriteIndex];
                    normalCatCount++;
                }
            }
            //if normal cats are full, only generate power cats
            else if (powerCatCount < Global.Instance.catPowerNumber)
            {
                int spriteIndex = Random.Range(0, PowerSpriteArray.Length);
                catArray[i].GetComponent<Cat>().GetComponent<SpriteRenderer>().sprite = PowerSpriteArray[spriteIndex];
                powerCatCount++;
            }
            //if power cats are full, only generate normal cats
            else
            {
                int spriteIndex = Random.Range(0, NormalSpriteArray.Length);
                catArray[i].GetComponent<Cat>().GetComponent<SpriteRenderer>().sprite = NormalSpriteArray[spriteIndex];
                normalCatCount++;
            }
        }

    }


}
