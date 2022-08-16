using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyTowerPopup : MonoBehaviour
{
    [SerializeField] GameObject TowerPopup;
    [SerializeField] GameObject CloseButton;
    void Start()
    {
        Init();
    }
    void Init()
    {
        for(int i = 0; i < TowerPopup.transform.childCount; i++)
        {
            TowerPopup.transform.GetChild(i).GetComponent<TowerBuyButton>().SetUp(TowerDataKeeper.Instance.GetTower(i));
        }
    }
    public void OnCloseClick()
    {
        PopUpAnimationManager.HidePanel(TowerPopup);
        CloseButton.SetActive(false);
    }
}
