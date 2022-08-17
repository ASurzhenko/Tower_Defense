using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PData
{
    public static event Action<float> OnPlayerSoftCashChange;
	public static event Action<float> OnPlayerHealthChange;
    public static float SoftCash {
		get
		{
			if (PlayerData.GetFloat(GameConstants.SoftCash) <= 0)
			{
				return 0;
			}

			return PlayerData.GetFloat(GameConstants.SoftCash);
		}
	
		set {
			PlayerData.SetFloat(GameConstants.SoftCash, value);
			OnPlayerSoftCashChange?.Invoke(value);
		}
	}
	public static float PlayerHealth {
		get
		{
			if (PlayerData.GetFloat(GameConstants.PlayerHealth) <= 0)
			{
				return 0;
			}

			return PlayerData.GetFloat(GameConstants.PlayerHealth);
		}
	
		set {
			PlayerData.SetFloat(GameConstants.PlayerHealth, value);
			OnPlayerHealthChange?.Invoke(value);
		}
	}
    public static int LastLevelIndex {
		get => PlayerData.GetInt(GameConstants.LastLevelIndex);
		set {
			PlayerData.SetInt(GameConstants.LastLevelIndex, value);
		}
	}
}
