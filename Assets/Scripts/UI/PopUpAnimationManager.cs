using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public static class PopUpAnimationManager
{
    static float DefaultPanelShowPopDuration = 0.5f;
    public static Tween ShowPanel(GameObject Panel, bool HasBackgroundFade = true, float BackGroundPanelOpacity = 0.7f, float customScale = 1f)
    {
        Panel.transform.localScale = new Vector3(0, 0, 0);
        if (Panel.GetComponent<CanvasGroup>() != null)
        {
            Panel.GetComponent<CanvasGroup>().alpha = 0;
        }
        Panel.SetActive(true);

        if (HasBackgroundFade)
        {
            BackgroundShade(Panel.GetComponent<Image>(), BackGroundPanelOpacity);
        }

        if (Panel.GetComponent<CanvasGroup>() != null)
        {
            ShowFade(Panel.GetComponent<CanvasGroup>(), true);
        }

        return ShowScale(Panel.transform, true, null, -1, customScale);
    }

    public static Tween HidePanel(GameObject Panel, bool HasBackgroundFade = true, bool DoCanvasGroup = true, System.Action OnComplete = null, float customScale = 1f)
    {
        Panel.transform.localScale = new Vector3(customScale, customScale, customScale);

        if (Panel.GetComponent<CanvasGroup>() != null)
        {
            Panel.GetComponent<CanvasGroup>().alpha = 1;
        }

        if (HasBackgroundFade)
        {
            BackgroundShade(Panel.GetComponent<Image>(), 0);
        }

        if(Panel.GetComponent<CanvasGroup>() != null && DoCanvasGroup)
        {
            ShowFade(Panel.GetComponent<CanvasGroup>(), false);
        }

        return ShowScale(Panel.transform, false, delegate {
            Panel.SetActive(false);
            OnComplete?.Invoke();
        });
    }

    public static void BackgroundShade(Image ShadeIMG, float shadeColor, float Duration = -1f)
    {
        if(Duration < 0)
        {
            Duration = DefaultPanelShowPopDuration;
        }

        PopUpAnimationExecutor.Shade(ShadeIMG, shadeColor, Duration);
    }

    public static Tween ShowFade(CanvasGroup FadeingImage, bool Show , float Duration = -1f, Action OnComplete = null)
    {
        if (Duration < 0)
        {
            Duration = DefaultPanelShowPopDuration;
        }

        if (Show)
        {
            return PopUpAnimationExecutor.FadeIn(FadeingImage, Duration, () => OnComplete?.Invoke());
        }
        else
        {
            return PopUpAnimationExecutor.FadeOut(FadeingImage, Duration, () => OnComplete?.Invoke());
        }
    }

    public static Tween ShowScale(Transform Panel, bool Show, System.Action OnCompleteAction, float Duration = -1f, float customScale = 1f)
    {
        if (Duration < 0)
        {
            Duration = DefaultPanelShowPopDuration;
        }

        if (Show)
        {
           return PopUpAnimationExecutor.Scale_FadeIn(Panel, Duration, customScale);
        }
        else
        {
           return PopUpAnimationExecutor.Scale_FadeOut(Panel, Duration, OnCompleteAction);
        }
    }
}
