using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapObject : TObject
{
    [SerializeField] private Tilemap RoadTilemap;
    [SerializeField] private Tilemap DeployTilemap;
    [SerializeField] private List<WayPointObject> WayPointObjects;

    private readonly List<TileData> RoadTileDatas = new();
    private readonly List<TileData> DeployTileDatas = new();
    private readonly Dictionary<Vector3Int, TileData> TileDatas = new();

    protected override void ObjectActive()
    {
        base.ObjectActive();

        TileDatas.Clear();

        InitRoadTileData();
        InitDeployTileData();
    }

    private void InitDeployTileData()
    {
        DeployTileDatas.Clear();

        var xSize = DeployTilemap.size.x;
        var ySize = DeployTilemap.size.y;
        var zSize = DeployTilemap.size.z;
        for (int x = DeployTilemap.cellBounds.position.x; x < xSize; x++)
        {
            for (int y = DeployTilemap.cellBounds.position.y; y < ySize; y++)
            {
                for (int z = DeployTilemap.cellBounds.position.z; z < zSize; z++)
                {
                    var tilePosition = new Vector3Int(x, y, z);
                    var tile = DeployTilemap.GetTile<Tile>(tilePosition);
                    if (tile == null)
                    {
                        continue;
                    }
                    var tileData = new TileData(tilePosition, MapEnum.ETileType.Deploy);
                    DeployTileDatas.Add(tileData);
                    TileDatas[tileData.Position] = tileData;
                }
            }
        }
    }

    private void InitRoadTileData()
    {
        RoadTileDatas.Clear();

        var xSize = RoadTilemap.size.x;
        var ySize = RoadTilemap.size.y;
        var zSize = RoadTilemap.size.z;
        for (int x = RoadTilemap.cellBounds.position.x; x < xSize; x++)
        {
            for (int y = RoadTilemap.cellBounds.position.y; y < ySize; y++)
            {
                for (int z = RoadTilemap.cellBounds.position.z; z < zSize; z++)
                {
                    var tilePosition = new Vector3Int(x, y, z);
                    var tile = RoadTilemap.GetTile<Tile>(tilePosition);
                    if(tile == null)
                    {
                        continue;
                    }
                    var tileData = new TileData(tilePosition, MapEnum.ETileType.Road);
                    RoadTileDatas.Add(tileData);
                    if (!TileDatas.ContainsKey(tileData.Position))
                    {
                        Debug.Log($"[MapObject.cs] 중첩 타일 오류 [{tileData.Position}]");
                        continue;
                    }
                    else
                    {
                        TileDatas[tileData.Position] = tileData;
                    }
                }
            }
        }
    }
}
