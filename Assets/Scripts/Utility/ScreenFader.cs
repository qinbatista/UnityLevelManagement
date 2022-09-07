using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScreenFader : MonoBehaviour
{
    [SerializeField] float _solidAlpha = 1f;
    [SerializeField] float _clearAlpha = 0f;
    [SerializeField] float _fadeDuration = 2f;
    [SerializeField] MaskableGraphic[] graphicsToFade;

    public float FadeDuration { get => _fadeDuration; set => _fadeDuration = value; }

    // void Start()
    // {
    //     FadeOff();
    // }
    void SetAlpha(float alpha)
    {
        foreach (MaskableGraphic graphic in graphicsToFade)
        {
            if (graphic != null)
            {
                graphic.canvasRenderer.SetAlpha(alpha);
            }
        }
    }
    void Fade(float targetAlpha, float duration)
    {
        foreach (MaskableGraphic graphic in graphicsToFade)
        {
            if(graphic!=null)
            {
                graphic.CrossFadeAlpha(targetAlpha, duration, true);
            }
        }
    }
    public void FadeOff()
    {
        SetAlpha(_solidAlpha);
        Fade(_clearAlpha, FadeDuration);
    }
    public void FadeOn()
    {
        SetAlpha(_clearAlpha);
        Fade(_solidAlpha, FadeDuration);
    }

}
