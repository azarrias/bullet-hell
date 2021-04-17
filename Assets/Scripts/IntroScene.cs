using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScene : MonoBehaviour
{
    public Object menuScene;
    public GameObject underDogsSprite;
    public float underDogsSpriteDuration = 2f;
    public GameObject gameTitleText;
    public float gameTitleTextDuration = 2f;

    private void Start()
    {
        underDogsSprite.SetActive(true);
        gameTitleText.SetActive(false);
        StartCoroutine(PlayIntro());
    }

    IEnumerator PlayIntro()
    {
        yield return new WaitForSeconds(underDogsSpriteDuration);
        underDogsSprite.SetActive(false);
        gameTitleText.SetActive(true);
        yield return new WaitForSeconds(gameTitleTextDuration);
        SceneManager.LoadScene(menuScene.name);
    }
}
