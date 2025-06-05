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

public class GameTileData
{
    public Vector3Int Position;
    public MapEnum.ETileType TileType;
    public TObject TObject;

    public GameTileData()
    {

    }

    public GameTileData(TileData tileData)
    {
        Position = tileData.Position;
        TileType = tileData.TileType;
        TObject = null;
    }
}