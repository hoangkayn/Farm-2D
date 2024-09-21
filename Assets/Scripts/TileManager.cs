using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : BaseMono
{
    protected static TileManager instance;
    public static TileManager Instance => instance;
    // Tilemap mà ta đang sử dụng trong game
    [SerializeField] protected Tilemap tilemap;
    public Tilemap Tilemap => tilemap;

    // Dictionary lưu trữ trạng thái của các tile theo vị trí
    [SerializeField] protected Dictionary<Vector3Int, TileSO> tileDataDictionary = new Dictionary<Vector3Int, TileSO>();
    public Dictionary<Vector3Int, TileSO> TileDataDictionary => tileDataDictionary;


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
    public void GenerateDefaultTiles()
    {
        // Giả sử map có kích thước là 10x10, tạo các tile mặc định
        for (int x = -40; x < 40; x++)
        {
            for (int y = -40; y < 40; y++)
            {
                Vector3Int position = new Vector3Int(x, y, 0);

                string resPath = "SO/Tile/Empty";
                TileSO empty = Resources.Load<TileSO>(resPath);
               
                // Đặt tile vào vị trí trên tilemap
                this.SetTile(position, empty);
            }
        }
    }
  
    // Set trạng thái của một tile tại vị trí nhất định
    public void SetTile(Vector3Int position, TileSO tileSO)
    {
        // Cập nhật thông tin trạng thái tile trong dictionary
        if (tileDataDictionary.ContainsKey(position))
        {
            tileDataDictionary[position] = tileSO;
        }
        else
        {
            tileDataDictionary.Add(position, tileSO);
        }

        tilemap.SetTile(position, tileSO.tile);
       
    }

    // Get thông tin trạng thái của một tile tại vị trí nhất định
    public TileSO GetTileSO(Vector3Int position)
    {
        if (tileDataDictionary.TryGetValue(position, out TileSO tileSO))
        {
            return tileSO;
        }
        return null; 
    }

  
    }

