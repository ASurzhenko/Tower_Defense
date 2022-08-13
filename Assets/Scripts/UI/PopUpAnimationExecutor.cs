using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;

public static class PopUpAnimationExecutor
{
    public static Tween Shade(Image ShadeImage, float ShadeColor, float duration)
    {
        Color color = ShadeImage.color;
        color.a = (ShadeColor > 0.5f ? 0f : color.a);
        ShadeImage.color = color;

        return DOTween.To(() => color.a, x => color.a = x, ShadeColor, duration).OnUpdate(delegate
        {
            ShadeImage.color = color;
        });
    }

    // Fade in the image, opacity 0 to 1
    public static Tween FadeIn(CanvasGroup canvasGroup, float Duration, Action OnComplete)
    {
        float f = 0;
        return DOTween.To(() => f, x => f = x, 1, Duration)
        .OnUpdate(delegate
        {
            canvasGroup.alpha = f;
        })
        .OnComplete(() => OnComplete?.Invoke());
    }

    // Fade out the image, opacity 1 to 0
    public static Tween FadeOut(CanvasGroup canvasGroup, float Duration, Action OnComplete)
    {
        float f = canvasGroup.alpha;
        return DOTween.To(() => f, x => f = x, 0, Duration)
        .OnUpdate(delegate
        {
            canvasGroup.alpha = f;
        })
        .OnComplete(() => OnComplete?.Invoke());
    }

    // Scale in the image , scale 0 to 1
    public static Tween Scale_FadeIn(Transform panel, float Duration, float customScale = 1f)
    {
        return panel.DOScale(new Vector3(customScale, customScale, 1), Duration).SetEase(Ease.OutBack);
    }

    // Scale out the image , scale 1 to 0
    public static Tween Scale_FadeOut(Transform panel, float Duration, System.Action onCompleteAction)
    {
        return panel.DOScale(new Vector3(0, 0, 0), Duration).SetEase(Ease.InBack).OnComplete(delegate {
            onCompleteAction?.Invoke();
        });
    }
}
