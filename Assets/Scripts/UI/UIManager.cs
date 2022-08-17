using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] TextMeshProUGUI[] cashTexts;
    [SerializeField] Image HealthFillbar;
    [SerializeField] GameObject GameOverPopup;
    [SerializeField] GameObject WinPopup;
    [SerializeField] TextMeshProUGUI WaveText;
    float maxPlayerHP => PlayerDataKeeper.Instance.playerData_SO.MaxPlayerHP;
    float currentPlayerHP => PData.PlayerHealth;
    public static Action OnGameOver;
    private void Awake() {
        Instance = this;
    }
    private void Start() {
        PData.PlayerHealth = maxPlayerHP;
        SetStartValues();
        // if(!PlayerData.GetBool(GameConstants.NotFirstLoad))
        // {
        //     SetStartValues();
        // }
        // else
        // {
        //     OnSoftCashChangeHandler(PData.SoftCash);
        //     OnPlayerHealthChangeHandler(PData.PlayerHealth);
        // }
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
        if(AudioManager.Instance.isSfxOn())
            AudioManager.Instance.PlaySound(SoundEnum.GameOverSound);

        PopUpAnimationManager.ShowPanel(GameOverPopup);
        OnGameOver?.Invoke();
    }
    public void ShowWinPanel()
    {
        if(AudioManager.Instance.isSfxOn())
            AudioManager.Instance.PlaySound(SoundEnum.WinSound);

        PopUpAnimationManager.ShowPanel(WinPopup);
    }

    public void ShowWaveText(int wave, int maxWaves)
    {
        WaveText.text = $"Wave {wave}/{maxWaves}";
        if(!WaveText.gameObject.activeInHierarchy)
        {
            WaveText.gameObject.SetActive(true);
            WaveText.DOFade(1, 1);
        }
    }
    public void RestartGame() => SceneLoadManager.Instance.LoadScene(SceneNames.LevelScene + 1);
}
