using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SaveManager : BaseMono
{
    protected static SaveManager instance;
    public static SaveManager Instance => instance;
    protected override void Awake()
    {
        base.Awake();
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    public void SaveGame()
    {
        GameSaveData saveData = new GameSaveData();

        // Lưu thông tin của người chơi
        saveData.playerData = new PlayerData
        {

            items = Inventory.Instance.Items
        };

        // Lưu trạng thái của các tile
        saveData.tileSaveDataList = new List<TileSaveData>();
        foreach (var kvp in TileManager.Instance.TileDataDictionary)
        {
           
            TileSaveData tileSaveData = new TileSaveData
            {
                position = kvp.Key,
                tileSO = kvp.Value
            };
            saveData.tileSaveDataList.Add(tileSaveData);
        }
   
        // Lưu thông tin thời gian trong game
      //  saveData.currentDay = TimeManager.Instance.currentDay;
        //saveData.currentSeason = TimeManager.Instance.currentSeason;
        //saveData.currentYear = TimeManager.Instance.currentYear;

        // Serialize thành JSON
        string json = JsonUtility.ToJson(saveData);

        // Lưu JSON vào file
        string savePath = Application.persistentDataPath + "/savefile.json";
        System.IO.File.WriteAllText(savePath, json);
    }
   
}
