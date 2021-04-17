using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LerpImageColor : MonoBehaviour
{
    public Image image;
    public Color[] colors;
    public float lerpTime = 1f;
    private int index = 0;
    private float time = 0f;

    void Update()
    {
        image.color = Color.Lerp(image.color, colors[index], lerpTime * Time.deltaTime);
        time = Mathf.Lerp(time, 1f, lerpTime * Time.deltaTime);
        if (time > 0.9f)
        {
            time = 0f;
            index++;
            index = (index >= colors.Length) ? 0 : index;
        }
    }
}
