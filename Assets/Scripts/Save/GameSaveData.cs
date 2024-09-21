using System.Collections.Generic;

[System.Serializable]
public class GameSaveData
{
    public PlayerData playerData;
    public List<TileSaveData> tileSaveDataList;
    public int currentDay;
    public int currentSeason;
    public int currentYear;
}