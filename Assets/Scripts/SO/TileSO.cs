using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
[CreateAssetMenu(fileName = "Tile", menuName = "ScriptableObject/Tile")]
public class TileSO : ScriptableObject
{
    public Tile tile;
    public TileState tileState;

}
