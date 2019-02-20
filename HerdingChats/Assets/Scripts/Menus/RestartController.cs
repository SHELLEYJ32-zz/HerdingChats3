using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartController : MonoBehaviour
{
    public void Restart()
    {
        Global.Instance.score = 0;
        Global.Instance.endGame = false;
        SceneManager.LoadScene(sceneName: "MainMenu");
    }
}
