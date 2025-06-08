using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ObjectManager : Singletone<ObjectManager>
{
    private readonly Dictionary<string, AddressableData> AddressableDatas = new();

    /// <summary>
    /// 비동기로 오브젝트를 불러옵니다.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="addressableKey"></param>
    /// <returns></returns>
    public async UniTask<T> LoadObject_UniTask<T>(string addressableKey) where T : UnityEngine.Object
    {
        if (AddressableDatas.ContainsKey(addressableKey))
        {
            var addressableData = AddressableDatas[addressableKey];
            if (addressableData.ObjectHandle.Status == AsyncOperationStatus.Succeeded)
            {
                return addressableData.LoadObject as T;
            }
        }

        var objectHandle = Addressables.LoadAssetAsync<T>(addressableKey);
        await objectHandle;
        if (objectHandle.Status != AsyncOperationStatus.Succeeded)
        {
            Addressables.Release(objectHandle);
            throw new Exception($"[ObjectManager.cs] ({nameof(LoadObject_UniTask)}) catch [{objectHandle.Status}]");
        }

        var newAddressableData = new AddressableData()
        {
            ObjectHandle = objectHandle,
            LoadObject = objectHandle.Result
        };
        AddressableDatas[addressableKey] = newAddressableData;
        return newAddressableData.LoadObject as T;
    }

    /// <summary>
    /// 비동기로 TObject를 가져오고 풀링 여부 확인한 후에 오브젝트를 변환해서 반환합니다.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="addressableKey"></param>
    /// <returns></returns>
    public async UniTask<T> GetTObject_UniTask<T>(string addressableKey) where T : TObject
    {
        var loadGameObject = await LoadObject_UniTask<GameObject>(addressableKey);
        if (loadGameObject == null)
        {
            return null;
        }

        if(!loadGameObject.TryGetComponent<TObject>(out var tObject))
        {
            return null;
        }

        TObject returnObject;
        if (tObject.IsPooling)
        {
            returnObject = PoolManager.Instance.GetPoolObject(addressableKey, tObject);
        }

        else
        {
            returnObject = Instantiate(tObject);
        }

        returnObject.gameObject.SetActive(false);

        return returnObject as T;
    }



    /// <summary>
    /// 씬 전환 시 어드레서블을 릴리즈하고 에셋이 언로드가 되는거까지 추적해야함 (Dictionary 충돌 방지용)
    /// </summary>
    public async UniTask SceneObjectRelease()
    {
        foreach (var addressableKey in AddressableDatas.Keys)
        {
            var objectHandle = AddressableDatas[addressableKey].ObjectHandle;
            objectHandle.Release();
        }

        AddressableDatas.Clear();

        await Resources.UnloadUnusedAssets().ToUniTask();
    }
}
