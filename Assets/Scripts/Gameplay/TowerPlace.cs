using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlace : MonoBehaviour
{
    public enum TowerState
    {
        Empty,
        Tower
    }
    [SerializeField] GameObject BuyPopup;
    [SerializeField] GameObject CloseButton;
    Tower_SO tower_SO;
    TowerState towerState;
    float offset = 1.5f;
    public static event Action<TowerPlace> OnTowerPlaceClicked;
    private void OnMouseUpAsButton() {
        if(IsPopupOpened()) return;
        TowerDataKeeper.Instance.CurrentTowerPlace = this;
        if(towerState == TowerState.Empty)
        {
            //open buy popup
            BuyPopup.transform.position = transform.position;
            if(transform.position.y > 0)
            {
                BuyPopup.transform.position -= new Vector3(0, offset, 0);
            }
            else
            {
                BuyPopup.transform.position += new Vector3(0, offset, 0);
            }
            PopUpAnimationManager.ShowPanel(BuyPopup);
            CloseButton.SetActive(true);
        }
    }
    bool IsPopupOpened() => BuyPopup.activeInHierarchy;
    public void CreateTower(int towerIndex)
    {
        towerState = TowerState.Tower;
        tower_SO = TowerDataKeeper.Instance.GetTower(towerIndex);
        GameObject tower = Instantiate(tower_SO.TowerPrefab, transform.position, Quaternion.identity, transform);
        tower.GetComponentInChildren<Tower>().SetUp(tower_SO);
        PopUpAnimationManager.HidePanel(BuyPopup);
        CloseButton.SetActive(false);
    }
    public void ShowSellPanel()
    {
        
    }
}
