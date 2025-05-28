using Cysharp.Threading.Tasks;
using System.Threading;
using System;
using UnityEngine;

public class TObject : MonoBehaviour
{
    [Header("TObject")]
    public string AddressableKey;
    public bool IsPooling;

    [HideInInspector] public int Index;
    [HideInInspector] public bool IsOn;

    private CancellationTokenSource ActiveCancellationToken;
    private readonly CancellationTokenSource ObjectCancellationToken = new();

    private void OnEnable()
    {
        OnEnableSetting();
    }

    protected virtual void OnEnableSetting()
    {

    }

    private void OnDisable()
    {
        OnDisableSetting();
    }

    protected virtual void OnDisableSetting()
    {

    }

    private void Start()
    {
        StartSetting();
    }

    protected virtual void StartSetting()
    {

    }

    private void OnDestroy()
    {
        ReleaseActiveToken();

        ObjectCancellationToken.Cancel();
        ObjectCancellationToken.Dispose();
    }

    protected virtual void ReleaseActiveToken()
    {
        if (ActiveCancellationToken == null || ActiveCancellationToken.IsCancellationRequested)
        {
            return;
        }

        ActiveCancellationToken.Cancel();
        ActiveCancellationToken.Dispose();
    }

    protected virtual void ObjectActive()
    {
        ReleaseActiveToken();
        ActiveCancellationToken = new();
        IsOn = true;
        gameObject.SetActive(true);
    }

    protected virtual void ObjectDisable()
    {
        ReleaseActiveToken();
        IsOn = false;
        gameObject.SetActive(false);
    }

    public async UniTask OnObjectActive_UniTask(float runDelay = 0f)
    {
        try
        {
            await UniTask.WaitForSeconds(runDelay, cancellationToken: ObjectCancellationToken.Token);
            if (IsOn)
            {
                return;
            }
            ObjectActive();
        }
        catch (ObjectDisposedException)
        {

        }
        catch (OperationCanceledException)
        {
        }
        catch (Exception ex)
        {
            Debug.Log($"[TObject.cs] ({nameof(OnObjectActive_UniTask)}) catch [{ex.Message}]");
        }
    }

    public async UniTask OnObjectDisable_UniTask(float runDelay = 0f)
    {
        try
        {
            await UniTask.WaitForSeconds(runDelay, cancellationToken: ObjectCancellationToken.Token);
            if (!IsOn)
            {
                return;
            }
            ObjectDisable();
            if (!IsPooling)
            {
                Destroy(gameObject);
                return;
            }
            PoolManager.Instance.ReturnPoolObject(this);
        }
        catch (ObjectDisposedException)
        {

        }
        catch (OperationCanceledException)
        {
        }
        catch (Exception ex)
        {
            Debug.Log($"[TObject.cs] ({nameof(OnObjectDisable_UniTask)}) catch [{ex.Message}]");
        }
    }
}
