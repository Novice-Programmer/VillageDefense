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
    /// 비동기로 오브젝트를 가져옵니다.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="addressableKey"></param>
    /// <returns></returns>
    private async UniTask<ResultData_Addressable<T>> InnerLoadObject_UniTask<T>(string addressableKey) where T : UnityEngine.Object
    {
        var result = new ResultData_Addressable<T>();
        if (AddressableDatas.ContainsKey(addressableKey))
        {
            var addressableData = AddressableDatas[addressableKey];
            if (addressableData.ObjectHandle.Status == AsyncOperationStatus.Succeeded)
            {
                result.ReturnObject = addressableData.LoadObject as T;
                result.IsSuccess = result.ReturnObject != null;
                return result;
            }
        }

        var objectHandle = Addressables.LoadAssetAsync<T>(addressableKey);
        await objectHandle;
        if (objectHandle.Status != AsyncOperationStatus.Succeeded)
        {
            Addressables.Release(objectHandle);
            throw new Exception($"[ObjectManager.cs] ({nameof(InnerLoadObject_UniTask)}) 오브젝트 불러오기 실패 catch [{objectHandle.Status}]");
        }

        var newAddressableData = new AddressableData()
        {
            ObjectHandle = objectHandle,
            LoadObject = objectHandle.Result
        };

        AddressableDatas[addressableKey] = newAddressableData;
        result.ReturnObject = newAddressableData.LoadObject as T;
        result.IsSuccess = result.ReturnObject != null;

        return result;
    }

    /// <summary>
    /// 비동기로 오브젝트를 불러옵니다.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="addressableKey"></param>
    /// <returns></returns>
    public async UniTask<T> LoadObject_UniTask<T>(string addressableKey) where T : UnityEngine.Object
    {
        var result = await InnerLoadObject_UniTask<T>(addressableKey);

        if (!result.IsSuccess)
        {
            return null;
        }

        return result.ReturnObject;
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
