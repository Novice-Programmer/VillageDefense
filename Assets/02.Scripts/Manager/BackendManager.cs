using BackEnd;
using UnityEngine;

public class BackendManager : Singletone<BackendManager>
{
    [HideInInspector] public bool IsInit;
    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        IsInit = false;
        BackendSetUp();
    }

    private void BackendSetUp()
    {
        var bro = Backend.Initialize();

        if (bro.IsSuccess())
        {
            IsInit = true;
            Debug.Log("성공");
        }
        else
        {
            Debug.LogError("초기화 실패 : " + bro.GetMessage());
        }
    }
}
