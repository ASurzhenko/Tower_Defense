using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TowerBuyButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI PriceText;
    [SerializeField] GameObject LockObject;
    [SerializeField] Image TowerImage;
    Tower_SO myTower_SO;
    float softCash => PData.SoftCash;
    TowerPlace currentTowerPlace => TowerDataKeeper.Instance.CurrentTowerPlace;
    private void OnEnable() {
		PData.OnPlayerSoftCashChange += OnSoftCashChangeHandler;
        OnSoftCashChangeHandler(softCash);
	}
	private void OnDisable() {
		PData.OnPlayerSoftCashChange -= OnSoftCashChangeHandler;
	}
    public void SetUp(Tower_SO tower_SO)
    {
        myTower_SO = tower_SO;
        TowerImage.sprite = tower_SO.TowerSprite;
        LockObject.SetActive(IsTowerLocked(tower_SO.BuildPrice));
        PriceText.text = tower_SO.BuildPrice.ToString();
        GetComponent<Button>().onClick.AddListener(() => CreateTower(transform.GetSiblingIndex()));
    }
    bool IsTowerLocked(float price) => softCash < price;
    public void CreateTower(int towerIndex)
    {
        if(IsTowerLocked(myTower_SO.BuildPrice)) return;
        PData.SoftCash -= myTower_SO.BuildPrice;
        currentTowerPlace.CreateTower(towerIndex);
    }
    void OnSoftCashChangeHandler(float softCash)
    {
        LockObject.SetActive(IsTowerLocked(myTower_SO.BuildPrice));
    }
}
