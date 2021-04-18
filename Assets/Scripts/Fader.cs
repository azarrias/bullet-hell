using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Fader
{
    public enum FadeType
    {
        FadeIn,
        FadeOut
    }

    public static IEnumerator Fade(RawImage fadeUIImage, FadeType fadeType, float fadeDuration)
    {
        float alpha = (fadeType == FadeType.FadeOut) ? 1 : 0;
        float targetAlpha = (fadeType == FadeType.FadeOut) ? 0 : 1;
        fadeUIImage.enabled = true;

        if (fadeType == FadeType.FadeOut)
        {
            while (alpha >= targetAlpha)
            {
                SetImageAlpha(ref alpha, fadeUIImage, fadeType, fadeDuration);
                Debug.Log(alpha);
                yield return null;
            }
        }
        else
        {
            while (alpha <= targetAlpha)
            {
                SetImageAlpha(ref alpha, fadeUIImage, fadeType, fadeDuration);
                yield return null;
            }
        }
    }

    private static void SetImageAlpha(ref float alpha, RawImage fadeUIImage, FadeType fadeType, float fadeDuration)
    {
        var color = fadeUIImage.color;
        color.a = alpha;
        fadeUIImage.color = color;
        alpha += ((fadeType == FadeType.FadeOut) ? -1 : 1) / fadeDuration * Time.deltaTime;
    }
}
