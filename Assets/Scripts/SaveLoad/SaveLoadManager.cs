using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager Instance {get; private set;}
    LocalStorage localStorage;
    void Awake() {
		Instance = this;
	}
    void Start() {
		localStorage = new LocalStorage();
		SetupData();
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
