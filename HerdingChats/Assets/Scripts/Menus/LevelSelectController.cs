using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectController : MonoBehaviour
{
    public void LevelOne()
    {
        SceneManager.LoadScene(sceneName: "SampleScene");
    }

    public void Back()
    {
        SceneManager.LoadScene(sceneName: "MainMenu");
    }
}
