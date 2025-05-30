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
