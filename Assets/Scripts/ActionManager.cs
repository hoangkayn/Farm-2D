using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActionManager : BaseMono
{
    protected static ActionManager instance;
    public static ActionManager Instance => instance;
    public ActionType currentActionType;
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
    public virtual void TillSoli(Vector3 worldPosition)
    {
       
        Animator animBody = PlayerCtrl.Instance.AnimBody;
        animBody.SetTrigger("Hoe");
        Animator animTool = PlayerCtrl.Instance.AnimTool;
        animTool.SetTrigger("Hoe");
        // Xác định vị trí tile mà người chơi click
        Vector3Int tilePosition = TileManager.Instance.Tilemap.WorldToCell(worldPosition);

        // Lấy dữ liệu tile hiện tại
        TileSO tileSO = TileManager.Instance.GetTileSO(tilePosition);

        if (tileSO != null && tileSO.tileState == TileState.Empty) // Nếu tile hiện tại là đất trống
        {
            // Đổi trạng thái tile thành "Đã cuốc"
            string resPath = "SO/Tile/Tile";
            tileSO = Resources.Load<TileSO>(resPath);
        }
    }
    public virtual void WaterSoli()
    {
        Debug.Log("WaterSoli");
    }
    public virtual void PlantSeed(Vector3 worldPosition)
    {
      
    }
    public virtual void Chop()
    {
        Debug.Log("Chop");
    }
    public virtual void BreakRock()
    {
        Debug.Log("BreakRock");
    }
 
}
