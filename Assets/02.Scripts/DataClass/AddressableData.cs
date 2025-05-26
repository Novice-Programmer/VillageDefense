using UnityEngine.ResourceManagement.AsyncOperations;

public class AddressableData
{
    public AsyncOperationHandle ObjectHandle;
    public UnityEngine.Object LoadObject;
}

public class ResultData_Addressable<T> : ResultData where T : UnityEngine.Object
{
    public T ReturnObject;
}