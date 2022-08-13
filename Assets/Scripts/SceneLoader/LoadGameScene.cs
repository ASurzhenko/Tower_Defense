using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadGameScene : MonoBehaviour
{
    private void Start() {
        SceneLoadManager.Instance.LoadScene(SceneNames.LevelScene + 1);
    }
}
