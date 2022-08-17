using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class TopPanel : MonoBehaviour
{
    void Start()
    {
        GetComponent<RectTransform>().DOAnchorPosY(-23f, 0.5f).SetEase(Ease.Linear).SetDelay(1.2f);
    }
}
