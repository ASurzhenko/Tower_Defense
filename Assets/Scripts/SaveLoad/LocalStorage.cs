using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LocalStorage : MonoBehaviour
{
    protected string savePath;
    private Dictionary<string, string> data;
    private PlayerDataContainer dataContainer;
    public LocalStorage()
    {
        this.savePath = Path.Combine(Application.persistentDataPath, "player.data");
        dataContainer = new PlayerDataContainer();
        this.LoadData();
    }
    public void LoadData()
    {
        LoadFromFile();
    }
    private void LoadFromFile()
    {
        FileStream fs = null;
        bool isError = false;
        if (File.Exists(savePath))
        {
            fs = new FileStream(savePath, FileMode.OpenOrCreate);
            //Debug.Log("SAVE PATH: " + fs);
            using (BinaryReader reader = new BinaryReader(fs))
            {
                try
                {
                    data = new Dictionary<string, string>();
                    int pairsCount = reader.ReadInt32();
                    for (int i = 0; i < pairsCount; i++)
                    {
                        var f = reader.ReadString();
                        var s = reader.ReadString();
                        data.Add(f, s);
                        //Debug.Log("LOAD FROM FILE: " + f);
                        //Debug.Log("LOAD FROM FILE: " + s);
                    }
                    dataContainer.SetData(data);
                }
                catch (System.Exception e)
                {
                    Debug.LogError(e);
                    isError = true;
                }
            }
            fs?.Dispose();
            if (isError)
            {
                CreateNewDataFile();
            }
        }
        else
        {
            CreateNewDataFile();
            SaveData(data);
        }
    }
    private void CreateNewDataFile()
    {
        var fs = File.Create(savePath);
        data = new Dictionary<string, string>();
        dataContainer.SetData(data);
        fs?.Dispose();
    }
    public void SaveData(Dictionary<string, string> data) {
		using (FileStream fs = new FileStream(savePath, FileMode.OpenOrCreate)) {
			using (BinaryWriter writer = new BinaryWriter(fs)) {
				writer.Write(data.Count);
				foreach (KeyValuePair<string, string> keyValue in data) {
					writer.Write(keyValue.Key);
					writer.Write(keyValue.Value);
				}
			}
		}
	}
    public PlayerDataContainer GetContainer() {
		return dataContainer;
	}
}
