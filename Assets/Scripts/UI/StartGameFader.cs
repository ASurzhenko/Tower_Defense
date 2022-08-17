using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class StartGameFader : MonoBehaviour
{
    void Start()
    {
        GetComponent<Image>().DOFade(0, 1);
    }
}
