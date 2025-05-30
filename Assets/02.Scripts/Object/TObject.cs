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

    protected CancellationTokenSource m_ActiveCancellationToken;
    private readonly CancellationTokenSource m_ObjectCancellationToken = new();

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

        m_ObjectCancellationToken.Cancel();
        m_ObjectCancellationToken.Dispose();
    }

    protected virtual void ReleaseActiveToken()
    {
        if (m_ActiveCancellationToken == null || m_ActiveCancellationToken.IsCancellationRequested)
        {
            return;
        }

        m_ActiveCancellationToken.Cancel();
        m_ActiveCancellationToken.Dispose();
    }

    protected virtual void ObjectActive()
    {
        ReleaseActiveToken();
        m_ActiveCancellationToken = new();
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
            await UniTask.WaitForSeconds(runDelay, cancellationToken: m_ObjectCancellationToken.Token);
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
            await UniTask.WaitForSeconds(runDelay, cancellationToken: m_ObjectCancellationToken.Token);
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
