using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroScene : BaseScene
{
    public Object menuScene;
    public GameObject underDogsSprite;
    public float underDogsSpriteDuration = 2f;
    public GameObject gameTitleText;
    public float gameTitleTextDuration = 2f;
    public RawImage fadeUIImage;

    private void Start()
    {
        underDogsSprite.SetActive(true);
        gameTitleText.SetActive(false);
        StartCoroutine(PlayIntro());
    }

    IEnumerator PlayIntro()
    {
        yield return StartCoroutine(Fader.Fade(fadeUIImage, Fader.FadeType.FadeOut, 2f));
        yield return new WaitForSeconds(underDogsSpriteDuration);
        yield return StartCoroutine(Fader.Fade(fadeUIImage, Fader.FadeType.FadeIn, 1f));
        underDogsSprite.SetActive(false);
        gameTitleText.SetActive(true);
        yield return StartCoroutine(Fader.Fade(fadeUIImage, Fader.FadeType.FadeOut, 1f));
        yield return new WaitForSeconds(gameTitleTextDuration);
        yield return StartCoroutine(Fader.Fade(fadeUIImage, Fader.FadeType.FadeIn, 2f));
        SceneManager.LoadScene(MENU_SCENE);
    }
}
