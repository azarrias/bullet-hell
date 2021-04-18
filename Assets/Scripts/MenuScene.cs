using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScene : BaseScene
{
    public Object gameScene;
    public RawImage fadeUIImage;

    private void Start()
    {
        StartCoroutine(Fader.Fade(fadeUIImage, Fader.FadeType.FadeOut, 2f));
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(GAME_SCENE);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
