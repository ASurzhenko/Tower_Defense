using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadManager : MonoBehaviour
{
    public static SceneLoadManager Instance;
    private List<string> PersistingScenes = new List<string>();
    AsyncOperation asyncOperation;
    private void Awake()
    {
        Instance = this;
        PersistingScenes.Add(SceneNames.ManagerScreen);
    }
    public void LoadScene(string sceneName)
    {
        Debug.Log($"Loading Scene {sceneName}");
        StartCoroutine(LoadLoadingScene(sceneName, true));
    }
    public void LoadSceneOnTop(string sceneName)
    {
        Debug.Log($"Loading Scene on Top {sceneName}");
        StartCoroutine(LoadLoadingScene(sceneName, false));
    }
    IEnumerator LoadLoadingScene(string sceneName, bool ClearOldScenes)
    {
        if (ClearOldScenes)
        {
            for (int i = 0; i < SceneManager.sceneCount; i++)
            {
                var s = SceneManager.GetSceneAt(i);
                if (!IsPersistantScene(s.name))
                {
                    UnloadScene(s.name);
                }
            }
        }

        asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        asyncOperation.allowSceneActivation = true;  //!ClearOldScenes;
        yield return null;
    }
    public bool IsPersistantScene(string sceneName)
    {
        return PersistingScenes.Contains(sceneName);
    }
    public void UnloadScene(string sceneName)
    {
        if (HasScene(sceneName))
        {
            
            Debug.Log($"Unloading Scene {sceneName}");
            SceneManager.UnloadSceneAsync(sceneName);
        }
    }
    public bool HasScene(string sceneName)
    {
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (SceneManager.GetSceneAt(i).name.Equals(sceneName))
            {
                return true;
            }
        }
        return false;
    }
}
