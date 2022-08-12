using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;

public class PlayerDataContainer {
	private Dictionary<string, string> data;
	public Dictionary<string, string> Data => data;

	public void SetData(Dictionary<string, string> data) {
		this.data = data;
	}

	public void DeleteKey(string key) {
		if (key == null) throw new NullReferenceException("Key can't be null");
		if (data.ContainsKey(key)) {
			data.Remove(key);
		}
	}
	public float GetFloat(string key, float defaultValue) {
		if (key == null) throw new NullReferenceException("Key can't be null");
		float returnValue;
		if (data.ContainsKey(key) && float.TryParse(data[key], out returnValue)) {
			return returnValue;
		} else {
			return defaultValue;
		}
	}
	public float GetFloat(string key) {
		if (key == null) throw new NullReferenceException("Key can't be null");
		return GetFloat(key, 0f);
	}
	public int GetInt(string key, int defaultValue) {
		if (key == null) throw new NullReferenceException("Key can't be null");
		int returnValue;
		if (data.ContainsKey(key) && Int32.TryParse(data[key], out returnValue)) {
			return returnValue;
		} else {
			return defaultValue;
		}
	}

	public int GetInt(string key) {
		if (key == null) throw new NullReferenceException("Key can't be null");
		return GetInt(key, 0);
	}
	public string GetString(string key, string defaultValue) {
		if (key == null) throw new NullReferenceException("Key can't be null");
		if (data.ContainsKey(key)) {
			return data[key];
		} else {
			return defaultValue;
		}
	}
	public string GetString(string key) {
		if (key == null) throw new NullReferenceException("Key can't be null");
		if (data.ContainsKey(key)) {
			return data[key];
		} else {
			return null;
		}
	}
	public bool HasKey(string key) {
		if (key == null) throw new NullReferenceException("Key can't be null");
		return data.ContainsKey(key);
	}
	public void SetFloat(string key, float value) {
		if (key == null) throw new NullReferenceException("Key can't be null");
		if (data.ContainsKey(key)) {
			data[key] = value.ToString(CultureInfo.InvariantCulture);
		} else {
			data.Add(key, value.ToString(CultureInfo.InvariantCulture));
		}
	}
	public void SetInt(string key, int value) {
		if (key == null) throw new NullReferenceException("Key can't be null");
		if (data.ContainsKey(key)) {
			data[key] = value.ToString();
		} else {
			data.Add(key, value.ToString());
		}
	}
	public void SetString(string key, string value) {
		if (key == null) throw new NullReferenceException("Key can't be null");
		if (data.ContainsKey(key)) {
			data[key] = value.ToString();
		} else {
			data.Add(key, value.ToString());
		}
	}

	public void DeleteAll() {
		data = new Dictionary<string, string>();
	}
}