using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using UnityEngine;

public class StageManager : Singletone<StageManager>
{
    [SerializeField] private MapController MapController;
    [SerializeField] private WaveController WaveController;

    private CancellationTokenSource m_StageCancellationToken;

    protected virtual void ReleaseStageToken()
    {
        if (m_StageCancellationToken == null || m_StageCancellationToken.IsCancellationRequested)
        {
            return;
        }

        m_StageCancellationToken.Cancel();
        m_StageCancellationToken.Dispose();
    }

    public async UniTask InitStage_UniTask(int stageIndex)
    {
        ReleaseStageToken();

        if (!DataManager.Instance.GetStageData(stageIndex, out var stageData))
        {
            return;
        }

        await MapController.CreateMap(stageData.MapAddressableKey);
        var wayPointDatas = MapController.GetWayPointDatas();
        m_StageCancellationToken = new();
        WaveController.InitWaveData_UniTask(stageData, wayPointDatas, m_StageCancellationToken).Forget();
    }
}
