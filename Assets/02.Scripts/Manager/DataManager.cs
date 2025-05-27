using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataManager : Singletone<DataManager>
{
    [SerializeField] private StageCollection StageCollection;
    [SerializeField] private EnemyCollection EnemyCollection;

    private readonly Dictionary<int, GameStageData> m_StageDatas = new();
    private readonly Dictionary<EnemyEnum.EName, Dictionary<EnemyEnum.ERank, List<GameEnemyData>>> m_EnemyDatas = new();

    private bool IsInit = false;

    #region 데이터 변환

    private void InitData()
    {
        InitStageData();
        InitEnemyData();

        IsInit = true;
    }

    /// <summary>
    /// 스테이지 정보 변환 후 저장
    /// </summary>
    private void InitStageData()
    {
        var stageDatas = StageCollection.StageDatas;
        for (int i = 0, iLen = stageDatas.Count; i < iLen; i++)
        {
            var stageData = stageDatas[i];
            m_StageDatas.Add(stageData.Index, new(stageData));
        }
    }

    /// <summary>
    /// 적 정보 변환 후 이름과 랭크로 구분 짓고 레벨로 정렬 후 저장
    /// </summary>
    private void InitEnemyData()
    {
        // 저장
        var enemyDatas = EnemyCollection.EnemyDatas;
        for (int i = 0, iLen = enemyDatas.Count; i < iLen; i++)
        {
            var enemyData = enemyDatas[i];
            if (!m_EnemyDatas.ContainsKey(enemyData.Name))
            {
                m_EnemyDatas[enemyData.Name] = new();
            }

            if (!m_EnemyDatas[enemyData.Name].ContainsKey(enemyData.Rank))
            {
                m_EnemyDatas[enemyData.Name][enemyData.Rank] = new();
            }

            m_EnemyDatas[enemyData.Name][enemyData.Rank].Add(new(enemyData));
        }

        // 정렬
        foreach (var enemyName in m_EnemyDatas.Keys)
        {
            foreach (var enemyRank in m_EnemyDatas[enemyName].Keys)
            {
                var enemyLevelDatas = m_EnemyDatas[enemyName][enemyRank];
                m_EnemyDatas[enemyName][enemyRank] = enemyLevelDatas.OrderBy(v => v.Level).ToList();
            }
        }
    }

    public async UniTask InitData_UniTask()
    {
        if (IsInit)
        {
            return;
        }

        InitData();
        await UniTask.WaitUntil(() => IsInit);
    }

    #endregion

    #region 데이터 반환

    public bool GetStageData(int stageIndex, out GameStageData stageData)
    {
        if (!m_StageDatas.ContainsKey(stageIndex))
        {
            stageData = null;
            return false;
        }

        stageData = m_StageDatas[stageIndex];
        return true;
    }

    #endregion
}
