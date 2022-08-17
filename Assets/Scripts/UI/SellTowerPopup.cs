using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SellTowerPopup : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI PriceText;
    [SerializeField] Image TowerImage;
    [SerializeField] GameObject SellPopup;
    [SerializeField] GameObject CloseSellPopupButton;
    float sellPrice;
    TowerPlace towerPlace;
    bool blockClick;
    public void SetUp(Tower_SO tower_SO, TowerPlace towerPlace)
    {
        blockClick = false;
        this.towerPlace = towerPlace;
        sellPrice = tower_SO.BuildPrice / 2;
        PriceText.text = sellPrice.ToString();
        TowerImage.sprite = tower_SO.TowerSprite;
    }
    public void SellTower()
    {
        if(blockClick) return;
        blockClick = true;
        PData.SoftCash += sellPrice;
        towerPlace.SellTower();
    }
    public void CloseSellPopup()
    {
        PopUpAnimationManager.HidePanel(SellPopup);
        CloseSellPopupButton.SetActive(false);
    }
}
