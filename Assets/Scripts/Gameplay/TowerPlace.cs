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
    [SerializeField] GameObject SellPopup;
    [SerializeField] GameObject CloseBuyPopupButton;
    [SerializeField] GameObject CloseSellPopupButton;
    Tower_SO tower_SO;
    TowerState towerState;
    float offset = 1.5f;
    GameObject currentTower;
    public static event Action<TowerPlace> OnTowerPlaceClicked;
    bool blockClick;
    BoxCollider2D myCollider;
    private void Awake() {
        myCollider = GetComponent<BoxCollider2D>();
    }
    private void OnMouseUpAsButton() {
        if(IsPopupOpened()) return;
        TowerDataKeeper.Instance.CurrentTowerPlace = this;
        if(towerState == TowerState.Empty)
        {
            BuyPopup.transform.position = GetPopupPosition();
            PopUpAnimationManager.ShowPanel(BuyPopup);
            CloseBuyPopupButton.SetActive(true);
        }
    }
    bool IsPopupOpened() => BuyPopup.activeInHierarchy || SellPopup.activeInHierarchy;
    public void CreateTower(int towerIndex)
    {
        myCollider.enabled = false;
        towerState = TowerState.Tower;
        tower_SO = TowerDataKeeper.Instance.GetTower(towerIndex);
        currentTower = Instantiate(tower_SO.TowerPrefab, transform.position, Quaternion.identity, transform);
        currentTower.GetComponentInChildren<Tower>().SetUp(tower_SO);
        PopUpAnimationManager.HidePanel(BuyPopup);
        CloseBuyPopupButton.SetActive(false);
    }
    public void ShowSellPanel(Tower_SO tower_SO)
    {
        if(IsPopupOpened()) return;
        SellPopup.transform.position = GetPopupPosition();
        SellPopup.GetComponent<SellTowerPopup>().SetUp(tower_SO, this);
        PopUpAnimationManager.ShowPanel(SellPopup);
        CloseSellPopupButton.SetActive(true);
    }
    Vector3 GetPopupPosition()
    {
        Vector3 pos = transform.position;
        if(transform.position.y > 0)
        {
            pos -= new Vector3(0, offset, 0);
        }
        else
        {
            pos += new Vector3(0, offset, 0);
        }
        return pos;
    }
    public void SellTower()
    {
        if(AudioManager.Instance.isSfxOn())
            AudioManager.Instance.PlaySound(SoundEnum.CoinSound);
            
        myCollider.enabled = true;
        towerState = TowerState.Empty;
        CloseSellPopup();
        if(currentTower != null)
            Destroy(currentTower);
    }
    void CloseSellPopup()
    {
        PopUpAnimationManager.HidePanel(SellPopup);
        CloseSellPopupButton.SetActive(false);
    }
}
