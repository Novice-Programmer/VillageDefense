using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataManager : Singletone<DataManager>
{
    [SerializeField] private StageCollection StageCollection;
    [SerializeField] private EnemyCollection EnemyCollection;
    [SerializeField] private MasteryCollection MasteryCollection;
    [SerializeField] private CircleCollection CircleCollection;

    private readonly Dictionary<int, GameStageData> m_StageDatas = new();
    private readonly Dictionary<EnemyEnum.EName, Dictionary<EnemyEnum.ERank, Dictionary<int, GameEnemyData>>> m_EnemyDatas = new();
    private readonly Dictionary<CharacterEnum.EMasteryType, Dictionary<int, GameMasteryLevelData>> m_MasteryDatas = new();
    private readonly Dictionary<CharacterEnum.ECircleType, Dictionary<int, GameCircleLevelData>> m_CircleDatas = new();

    private bool IsInit = false;

    #region 데이터 변환

    private void InitData()
    {
        InitStageData();
        InitEnemyData();
        InitMasteryData();
        InitCircleData();

        IsInit = true;
    }

    private void InitStageData()
    {
        var stageDatas = StageCollection.StageDatas;
        for (int i = 0, iLen = stageDatas.Count; i < iLen; i++)
        {
            var stageData = stageDatas[i];
            m_StageDatas.Add(stageData.KeyData.Index, new(stageData));
        }
    }

    private void InitEnemyData()
    {
        // 저장
        var enemyDatas = EnemyCollection.EnemyDatas;
        for (int i = 0, iLen = enemyDatas.Count; i < iLen; i++)
        {
            var enemyData = enemyDatas[i];
            if (!m_EnemyDatas.TryGetValue(enemyData.KeyData.Name, out var rankDict))
            {
                rankDict = m_EnemyDatas[enemyData.KeyData.Name] = new();
            }

            if (!rankDict.TryGetValue(enemyData.KeyData.Rank, out var levelDict))
            {
                levelDict = rankDict[enemyData.KeyData.Rank] = new();
            }

            levelDict[enemyData.KeyData.Level] = new(enemyData);
        }
    }

    private void InitMasteryData()
    {
        var masteryDatas = MasteryCollection.MasteryDatas;
        for (int i = 0, iLen = masteryDatas.Count; i < iLen; i++)
        {
            var masteryData = masteryDatas[i];
            if (!m_MasteryDatas.TryGetValue(masteryData.MasteryType, out var typeDict))
            {
                typeDict = m_MasteryDatas[masteryData.MasteryType] = new();
            }

            var masteryLevelDatas = masteryData.MasteryLevelDatas;
            for (int j = 0, jLen = masteryLevelDatas.Count; j < jLen; j++)
            {
                var masteryLevelData = masteryLevelDatas[j];
                typeDict[masteryLevelData.KeyData.Level] = new(masteryLevelData);
            }
        }
    }

    private void InitCircleData()
    {
        var circleDatas = CircleCollection.CircleDatas;
        for (int i = 0, iLen = circleDatas.Count; i < iLen; i++)
        {
            var circleData = circleDatas[i];
            if (!m_CircleDatas.TryGetValue(circleData.CircleType, out var typeDict))
            {
                typeDict = m_CircleDatas[circleData.CircleType] = new();
            }

            var circleLevelDatas = circleData.CircleLevelDatas;
            for (int j = 0, jLen = circleLevelDatas.Count; j < jLen; j++)
            {
                var circleLevelData = circleLevelDatas[j];
                typeDict[circleLevelData.KeyData.Level] = new(circleLevelData);
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

    public bool GetStageData(StageKeyData keyData, out GameStageData stageData)
    {
        return m_StageDatas.TryGetValue(keyData.Index, out stageData);
    }

    public bool GetEnemyData(EnemyKeyData keyData, out GameEnemyData enemyData)
    {
        enemyData = null;
        return m_EnemyDatas.TryGetValue(keyData.Name, out var rankDict)
            && rankDict.TryGetValue(keyData.Rank, out var levelDict)
            && levelDict.TryGetValue(keyData.Level, out enemyData);
    }

    public bool GetMasteryData(MasteryKeyData keyData, out GameMasteryLevelData masteryLevelData)
    {
        masteryLevelData = null;
        return m_MasteryDatas.TryGetValue(keyData.MasteryType, out var typeDict)
            && typeDict.TryGetValue(keyData.Level, out masteryLevelData);
    }

    public bool GetCircleData(CircleKeyData keyData, out GameCircleLevelData circleLevelData)
    {
        circleLevelData = null;
        return m_CircleDatas.TryGetValue(keyData.CircleType, out var typeDict)
            && typeDict.TryGetValue(keyData.Level, out circleLevelData);
    }
    #endregion
}
