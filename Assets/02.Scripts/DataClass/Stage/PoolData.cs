using System.Collections.Generic;
using UnityEngine;

public class PoolData
{
    public string AddressableKey;
    public List<TObject> ActiveObjects;
    public Queue<TObject> PoolObjects;
    public GameObject ParentObject;

    public PoolData()
    {

    }

    public PoolData(string addressableKey, GameObject parentObject)
    {
        AddressableKey = addressableKey;
        ActiveObjects = new();
        PoolObjects = new();
        ParentObject = parentObject;
    }
}