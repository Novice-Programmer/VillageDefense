using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : Singletone<MapManager>
{

    public async UniTask CreateMap(string mapAddressableKey)
    {
        /*
        var stageMapClass = await ObjectManager.Instance.LoadObject_UniTask<MapObject>(mapAddressableKey);
        await MapObject.ActiveObject_UniTask();
        스테이지맵_Object = 스테이지맵Class.gameObject;

        // 맵 설정
        var 스테이지맵Object = GameObject.FindWithTag(Const_맵태그명_string);
        스테이지타일맵_Tilemap = 스테이지맵Object.GetComponent<Tilemap>();
        타일Data_Dictionary.Clear();
        var xSize = 스테이지타일맵_Tilemap.size.x;
        var ySize = 스테이지타일맵_Tilemap.size.y;
        var zSize = 스테이지타일맵_Tilemap.size.z;
        for (int x = 스테이지타일맵_Tilemap.cellBounds.position.x; x < xSize; x++)
        {
            for (int y = 스테이지타일맵_Tilemap.cellBounds.position.y; y < ySize; y++)
            {
                for (int z = 스테이지타일맵_Tilemap.cellBounds.position.z; z < zSize; z++)
                {
                    var 타일좌표Vector3Int = new Vector3Int(x, y, z);
                    var 타일Tile = 스테이지타일맵_Tilemap.GetTile<Tile>(타일좌표Vector3Int);
                    var 타일값int = 0;
                    if (타일Tile != null)
                    {
                        타일값int = 타일값_가져오기(타일Tile.sprite);
                    }
                    var 타일Data = new Data_타일()
                    {
                        좌표_Vector3Int = new Vector3Int(x, y, z),
                        타일기본값_int = 타일값int,
                        타일현재값_int = 타일값int
                    };
                    타일Data_Dictionary[타일좌표Vector3Int] = 타일Data;
                }
            }
        }

        포인트Data_List.Clear();
        for (int i = 0, iLen = 스테이지맵_Object.transform.childCount; i < iLen; i++)
        {
            var 자식Object = 스테이지맵_Object.transform.GetChild(i);
            if (자식Object.CompareTag("Point"))
            {
                var 포인트_Data = new Data_포인트
                {
                    웨이포인트Object_List = new List<GameObject>()
                };

                for (int j = 0, jLen = 자식Object.childCount; j < jLen; j++)
                {
                    if (j == 0)
                    {
                        포인트_Data.스폰포인트_GameObject = 자식Object.GetChild(0).gameObject;
                    }
                    else
                    {
                        포인트_Data.웨이포인트Object_List.Add(자식Object.GetChild(j).gameObject);
                    }
                }

                포인트Data_List.Add(포인트_Data);
            }
        }
        */
    }
}
