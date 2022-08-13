using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenScale : MonoBehaviour
{
    public enum ScreenCodes
    {
        Normal,
        IphoneX,
        Ipad
    };
    public static ScreenCodes CurrentWorkingSize{get; private set;}
    private void Start() {
        CurrentWorkingSize = GetCurrentScreenType();
    }
    public ScreenCodes GetCurrentScreenType()
    {
        float x = Screen.width;
        float y = Screen.height;

        float ratio = x / y;

        if (ratio > 1.8f)
        {
            // iPhoneX
            return ScreenCodes.IphoneX;
        }
        else if (ratio < 1.5f)
        {
            // ipad
            return ScreenCodes.Ipad;
        }
        else
        {
            // normal
            return ScreenCodes.Normal;
        }
    }
}
