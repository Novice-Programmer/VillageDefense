using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapObject : TObject
{
    [SerializeField] private Tilemap RoadTilemap;
    [SerializeField] private Tilemap DeployTilemap;
    [SerializeField] private List<WayPointObject> WayPointObjects;

    public Dictionary<int, WayPointData> WayPointDatas => m_WayPointDatas;

    private readonly Dictionary<Vector3Int, GameTileData> m_RoadTileDatas = new();
    private readonly Dictionary<Vector3Int, GameTileData> m_DeployTileDatas = new();
    private readonly Dictionary<int, WayPointData> m_WayPointDatas = new();


    protected override void OnObjectActive()
    {
        base.OnObjectActive();

        InitRoadTileData();
        InitDeployTileData();
        InitWayPointData();
    }

    private void InitDeployTileData()
    {
        m_DeployTileDatas.Clear();

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
                    var tileData = new TileData(tilePosition, MapHelper.ETileType.Deploy);
                    m_DeployTileDatas[tilePosition] = new(tileData);
                }
            }
        }
    }

    private void InitRoadTileData()
    {
        m_RoadTileDatas.Clear();

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
                    if (tile == null)
                    {
                        continue;
                    }
                    var tileData = new TileData(tilePosition, MapHelper.ETileType.Road);
                    m_RoadTileDatas[tilePosition] = new(tileData);
                }
            }
        }
    }

    private void InitWayPointData()
    {
        m_WayPointDatas.Clear();

        for (int i = 0, iLen = WayPointObjects.Count; i < iLen; i++)
        {
            var wayPointObject = WayPointObjects[i];
            m_WayPointDatas[wayPointObject.Index] = wayPointObject.GetWayPointData();
        }
    }
}
