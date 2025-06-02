using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MapController : MonoBehaviour
{
    private TObject m_SelectObject;
    private MapObject m_MapObject;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
            SelectTile(Input.mousePosition);
        }
    }
    private void SelectTile(Vector3 mousePosition)
    {
        var worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        //var 타일맵위치Vector3Int = 스테이지타일맵_Tilemap.WorldToCell(카메라위치Vector3);
        //if (!타일Data_Dictionary.ContainsKey(타일맵위치Vector3Int))
        //{
        //    return;
        //}

        //var 타일Data = 타일Data_Dictionary[타일맵위치Vector3Int];
        //타일표시생성_UniTask(타일Data.타일현재값_int, 타일맵위치Vector3Int).Forget();

        //PopupManager.Instance.팝업열기(Enum_팝업종류.설치목록, Helper.ToJson(new Data_팝업_설치목록(타일Data.좌표_Vector3Int, 타일Data.타일현재값_int)));
    }

    public Dictionary<int, WayPointData> GetWayPointDatas()
    {
        return m_MapObject.WayPointDatas;
    }

    public async UniTask CreateMap(string mapAddressableKey)
    {
        m_MapObject = await ObjectManager.Instance.SpawnTObject_UniTask<MapObject>(mapAddressableKey);
        await m_MapObject.OnObjectActive_UniTask();
    }
}
