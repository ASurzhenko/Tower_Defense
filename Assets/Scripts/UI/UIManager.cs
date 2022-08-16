using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private TextMeshProUGUI[] cashTexts;
    [SerializeField] Image HealthFillbar;
    float maxPlayerHP => PlayerDataKeeper.Instance.playerData_SO.MaxPlayerHP;
    float currentPlayerHP => PData.PlayerHealth;
    private void Awake() {
        Instance = this;
    }
    private void Start() {
        PData.PlayerHealth = maxPlayerHP;
        if(!PlayerData.GetBool(GameConstants.NotFirstLoad))
        {
            SetStartValues();
        }
        else
        {
            OnSoftCashChangeHandler(PData.SoftCash);
            OnPlayerHealthChangeHandler(PData.PlayerHealth);
        }
    }
    void SetStartValues()
    {
        PlayerData.SetBool(GameConstants.NotFirstLoad, true);
        PData.SoftCash = 300f;
        PData.PlayerHealth = maxPlayerHP;
        HealthFillbar.fillAmount = 1;
        PlayerData.Save();
    }
    private void OnEnable() {
		PData.OnPlayerSoftCashChange += OnSoftCashChangeHandler;
        PData.OnPlayerHealthChange += OnPlayerHealthChangeHandler;
	}
	private void OnDisable() {
		PData.OnPlayerSoftCashChange -= OnSoftCashChangeHandler;
        PData.OnPlayerHealthChange -= OnPlayerHealthChangeHandler;
	}
    void OnSoftCashChangeHandler(float softCash) 
    {
		Array.ForEach(cashTexts, (x) => x.text = softCash.ToString());
	}
    void OnPlayerHealthChangeHandler(float healthAmount)
    {
        HealthFillbar.fillAmount = currentPlayerHP / maxPlayerHP;
    }
    public void ShowGameOverPanel()
    {
        Debug.Log("Show Game Over Panel!");
    }
}
