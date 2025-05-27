using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singletone<PoolManager>
{
    private readonly Dictionary<string, PoolData> PoolDatas = new();

    public TObject GetPoolObject(string addressableKey, TObject objectPrefab)
    {
        // 풀링 정보가 없을 경우 풀링 정보 생성
        if (!PoolDatas.ContainsKey(addressableKey))
        {
            var parentObject = new GameObject($"Parent_{addressableKey}");
            parentObject.transform.parent = transform;
            PoolDatas[addressableKey] = new(addressableKey, parentObject);
        }

        // 풀링 가능한 오브젝트가 없을 경우 풀링 오브젝트 생성
        if (PoolDatas[addressableKey].PoolObjects.Count == 0)
        {
            var createObject = Instantiate(objectPrefab, PoolDatas[addressableKey].ParentObject.transform);
            PoolDatas[addressableKey].PoolObjects.Enqueue(createObject);
        }

        // 풀링 가능한 오브젝트 가져와서 반환
        var poolObject = PoolDatas[addressableKey].PoolObjects.Dequeue();
        PoolDatas[addressableKey].ActiveObjects.Add(poolObject);

        return poolObject;
    }

    public void ReturnPoolObject(TObject returnObject)
    {
        returnObject.transform.parent = PoolDatas[returnObject.AddressableKey].ParentObject.transform;
        PoolDatas[returnObject.AddressableKey].PoolObjects.Enqueue(returnObject);
        var activeIndex = PoolDatas[returnObject.AddressableKey].ActiveObjects.FindIndex(v => v.Index == returnObject.Index);
        PoolDatas[returnObject.AddressableKey].ActiveObjects.RemoveAt(activeIndex);
    }
}
