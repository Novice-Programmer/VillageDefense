using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    private readonly List<EnemyObject> SpawnEnemys = new();

    private async UniTask ReleaseSpawnEnemy_UniTask()
    {
        try
        {
            for (int i = 0, iLen = SpawnEnemys.Count; i < iLen; i++)
            {
                var spawnEnemy = SpawnEnemys[i];
                if (!spawnEnemy.IsOn)
                {
                    continue;
                }
                await spawnEnemy.DisactiveObject_UniTask();
            }

            SpawnEnemys.Clear();
        }
        catch (Exception ex)
        {
            Debug.Log($"[WaveController.cs] ({nameof(ReleaseSpawnEnemy_UniTask)}) catch [{ex.Message}]");
        }
    }

    public async UniTask InitWaveData_UniTask(GameStageData stageData, Dictionary<int, WayPointData> wayPointDatas, CancellationTokenSource cancellationToken)
    {
        await ReleaseSpawnEnemy_UniTask();
        try
        {
            await UniTask.WaitForSeconds(stageData.StageWaitTime, cancellationToken: cancellationToken.Token);

            var waveIndex = 0;
            var waveCount = stageData.WaveDatas.Count;
            var defaultWayPointData = wayPointDatas.Values.First();

            // 모든 웨이브 정보
            while (waveIndex < waveCount)
            {
                var waveData = stageData.WaveDatas[waveIndex];
                await UniTask.WaitForSeconds(waveData.WaveWaitTime, cancellationToken: cancellationToken.Token);
                var spawnDatas = waveData.SpawnDatas;
                // 모든 웨이브 스폰 정보
                for (int i = 0, iLen = spawnDatas.Count; i < iLen; i++)
                {
                    var spawnData = spawnDatas[i];
                    var wayPointData = wayPointDatas.ContainsKey(spawnData.WayPointIndex) ? wayPointDatas[spawnData.WayPointIndex] : defaultWayPointData;
                    var spawnIndex = 0;
                    // 모든 스폰 정보
                    while(spawnIndex < spawnData.SpawnCount)
                    {
                        await UniTask.WaitForSeconds(spawnData.SpawnWaitTime, cancellationToken: cancellationToken.Token);
                        spawnIndex++;
                        if(!DataManager.Instance.GetEnemyData(spawnData.EnemyKeyData, out var enemyData))
                        {
                            Debug.LogWarning($"[WaveController.cs] ({nameof(InitWaveData_UniTask)}) Warning [Not Enemy Data]");
                            continue;
                        }
                        var enemyObject = await ObjectManager.Instance.GetTObject_UniTask<EnemyObject>(enemyData.ObjectAddressableKey);
                        if(enemyObject == null)
                        {
                            Debug.LogWarning($"[WaveController.cs] ({nameof(InitWaveData_UniTask)}) Warning [Not EnemyObject]");
                            continue;
                        }
                        await enemyObject.InitEnemy_UniTask(enemyData, wayPointData);
                        await enemyObject.ActiveObject_UniTask();
                    }
                }
                waveIndex++;
            }
        }
        catch (Exception ex)
        {
            Debug.Log($"[WaveController.cs] ({nameof(InitWaveData_UniTask)}) catch [{ex.Message}]");
        }
    }
}
