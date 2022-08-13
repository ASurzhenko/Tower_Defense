using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadSceneAsync(SceneNames.ManagerScreen);
    }
}