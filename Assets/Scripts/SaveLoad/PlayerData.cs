using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    private static PlayerDataContainer playerDataContainer;
	public static Dictionary<string, string> Data => playerDataContainer.Data;
	private static SaveLoadManager saveLoadManager;
    public static void SetDataContainer(PlayerDataContainer dataContainer) {
		playerDataContainer = dataContainer;
	}
	public static void SetDataManager(SaveLoadManager slManager) {
		saveLoadManager = slManager;
	}
	public static float GetFloat(string saveTag) {
		if (playerDataContainer == null) throw new NullReferenceException("PlayerDataContainer has not set currectly");
		return playerDataContainer.GetFloat(saveTag);
	}
	public static void SetFloat(string saveTag, float value) {
		if (playerDataContainer == null) throw new NullReferenceException("PlayerDataContainer has not set currectly");
		playerDataContainer.SetFloat(saveTag, value);
	}
	public static int GetInt(string saveTag)
	{
		if (playerDataContainer == null) throw new NullReferenceException("PlayerDataContainer has not set currectly");
		return playerDataContainer.GetInt(saveTag);
	}
	public static void SetInt(string saveTag, int value)
	{
		if (playerDataContainer == null) throw new NullReferenceException("PlayerDataContainer has not set currectly");
		playerDataContainer.SetInt(saveTag, value);
	}
	public static bool GetBool(string saveTag)
	{
		if (playerDataContainer == null) throw new NullReferenceException("PlayerDataContainer has not set currectly");
		return playerDataContainer.GetInt(saveTag) >= 1;
	}
	public static void SetBool(string saveTag, bool value)
	{
		if (playerDataContainer == null) throw new NullReferenceException("PlayerDataContainer has not set currectly");
		playerDataContainer.SetInt(saveTag, value ? 1 : 0);
	}
	public static string GetString(string tag)
	{
		if (playerDataContainer == null) throw new NullReferenceException("PlayerDataContainer has not set currectly");
		return playerDataContainer.GetString(tag);
	}
	public static void SetString(string tag, string toString)
	{
		if (playerDataContainer == null) throw new NullReferenceException("PlayerDataContainer has not set currectly");
		playerDataContainer.SetString(tag, toString);
	}
    public static void SetDouble(string controllerSaveTag, double value)
	{
		SetString(controllerSaveTag, value.ToString(CultureInfo.InvariantCulture));
	}
	public static double GetDouble(string tag)
	{
		if (!string.IsNullOrEmpty(GetString(tag)))
		{
			return double.Parse(GetString(tag), CultureInfo.InvariantCulture);
		}

		return 0;
	}
	public static void FreeDataContainer() {
		playerDataContainer.DeleteAll();
	}
	public static void DeleteAll()
	{
		if (playerDataContainer == null) throw new NullReferenceException("PlayerDataContainer has not set currectly");
		saveLoadManager.DeleteAll();
	}
	private static bool isSaving = false;
	public static void Save() {
		if (playerDataContainer == null) throw new NullReferenceException("PlayerDataContainer has not set currectly");
		if (isSaving) return;
		isSaving = true;
		try
		{
			saveLoadManager.SaveData();
		}
		catch (System.Exception e)
		{
			Debug.LogError(e);
		}
		isSaving = false;
	}
}
