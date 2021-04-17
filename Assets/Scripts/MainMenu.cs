using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Object gameScene;
    public void PlayGame()
    {
        SceneManager.LoadScene(gameScene.name);
    }
}
