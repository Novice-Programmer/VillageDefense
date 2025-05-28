using UnityEngine;

public class TileData
{
    public Vector3Int Position;
    public MapEnum.ETileType TileType;

    public TileData()
    {

    }

    public TileData(Vector3Int position, MapEnum.ETileType tileType = MapEnum.ETileType.None)
    {
        Position = position;
        TileType = tileType;
    }
}