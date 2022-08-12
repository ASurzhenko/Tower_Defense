using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager Instance {get; private set;}
    LocalStorage localStorage;
    void Awake() {
		if (Instance != null) {
            localStorage = new LocalStorage();
			PlayerData.SetDataContainer(localStorage.GetContainer());
			Instance.SetupData();
			Destroy(gameObject);
			return;
		}
		Instance = this;
	}
    void Start() {
		if (Instance == this) {
            localStorage = new LocalStorage();
			SetupData();
		}
		DontDestroyOnLoad(gameObject);
	}
    private void SetupData() {
        PlayerData.SetDataManager(Instance);
		PlayerData.SetDataContainer(localStorage.GetContainer());
	}
    public void SaveLocal() {
		localStorage.SaveData(PlayerData.Data);
	}
    public void DeleteAll() {
		PlayerData.FreeDataContainer();
		SaveData();
	}
    public void SaveData() {
		localStorage.SaveData(PlayerData.Data);
	}
}
