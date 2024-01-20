using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "TileConfig", menuName = "Game/TileConfig")]
public class TileConfig : ScriptableObject
{
    public List<Tile> TilePairs0;
    public List<Tile> TilePairs1;
}