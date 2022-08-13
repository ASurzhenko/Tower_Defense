using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ScreenScale;

public class CameraSize : MonoBehaviour
{
    ScreenCodes CurrentWorkingSize => ScreenScale.CurrentWorkingSize;
    Camera myCamera;
    private void Start() {
        myCamera = GetComponent<Camera>();
        if(CurrentWorkingSize == ScreenCodes.IphoneX)
            myCamera.orthographicSize = 5;
        else if(CurrentWorkingSize == ScreenCodes.Ipad)
            myCamera.orthographicSize = 6.8f;    
    }
}
