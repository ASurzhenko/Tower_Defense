using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using DG.Tweening;

public class LoadingScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Header_1;
    [SerializeField] TextMeshProUGUI Header_2;
    void Start()
    {
        Header_1.DOFade(1, 0.1f);
        Header_1.transform.DOScale(1, 0.3f).SetEase(Ease.InBounce).OnComplete(() =>
        {
            Header_2.DOFade(1, 2).SetDelay(1).OnComplete(() => 
            {
                Header_1.DOFade(0, 3);
                Header_2.DOFade(0, 3);
                StartCoroutine(LoadLevelScene());
            });
        });
    }
    IEnumerator LoadLevelScene()
    {
        yield return new WaitForSeconds(4);
        SceneManager.LoadSceneAsync(SceneNames.ManagerScreen);
    }
}
