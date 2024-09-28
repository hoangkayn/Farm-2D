using UnityEngine;

public class LoadManager : BaseMono
{
    protected static LoadManager instance;
    public static LoadManager Instance => instance;
    protected override void Awake()
    {
        base.Awake();
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
           
        }
    }
 /*   protected override void Start()
    {
        base.Start();
        if (GameManager.Instance == null)
        {
            Debug.LogError("GameManager.Instance is null.");
            return;
        }

        if (GameManager.Instance.isNewGame)
        {
            this.NewGame();
        }
        else
        {
            this.LoadGame();
        }
    }
    public void LoadGame()
    {
        Debug.Log("Load");
        string savePath = Application.persistentDataPath + "/savefile.json";
        if (System.IO.File.Exists(savePath))
        {
            // Đọc JSON từ file
            string json = System.IO.File.ReadAllText(savePath);
            GameSaveData saveData = JsonUtility.FromJson<GameSaveData>(json);

            // Khôi phục thông tin người chơi
           
            Inventory.Instance.SetItems(saveData.playerData.items);

            // Khôi phục thông tin của các tile
            foreach (var tileSaveData in saveData.tileSaveDataList)
            {
                TileManager.Instance.SetTile(tileSaveData.position, tileSaveData.tileSO);
            }

            // Khôi phục thời gian game
          //  TimeManager.Instance.SetTime(saveData.currentDay, saveData.currentSeason, saveData.currentYear);
        }
    }
    public void NewGame()
    {
    
        // Thiết lập các tile với trạng thái mặc định cho game mới
       TileManager.Instance.GenerateDefaultTiles();

        // Thiết lập thời gian ban đầu
      //  TimeManager.Instance.SetTime(1, 1, 1); // Ngày 1, Mùa Xuân, Năm 1
    }
 */
}
