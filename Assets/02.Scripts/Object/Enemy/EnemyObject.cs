using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : TObject
{
    [Header("Enemy")]
    [SerializeField] protected SpriteRenderer Appearance;
    [SerializeField] protected CircleCollider2D AttackCollider;

    public bool IsDead => m_IsDead;

    protected bool m_IsInit;
    protected bool m_IsDead;

    protected GameEnemyData m_EnemyData;

    protected float m_Exp;

    protected float m_Hp;
    protected float m_MaxHp;
    protected float m_HpRegen;

    protected float m_Mp;
    protected float m_MaxMp;
    protected float m_MpRegen;

    protected float m_CriticalRate;
    protected float m_CriticalResistRate;
    protected float m_CriticalDamage;

    protected float m_Accuracy;
    protected float m_Evasion;

    protected float m_PhysicalAttack;
    protected float m_PhysicalDefense;
    protected float m_PhysicalPenetration;
    protected float m_PhysicalReduction;

    protected float m_MagicAttack;
    protected float m_MagicDefense;
    protected float m_MagicPenetration;
    protected float m_MagicReduction;

    protected float m_AttackSpeed;
    protected float m_MoveSpeed;

    private int m_MoveIndex;
    private List<Vector3> m_WayPoints;

    protected const float MOVE_CHECK_DISTANCE = 0.05f;

    protected override void ObjectActive()
    {
        base.ObjectActive();
        MoveEnemy_UniTask().Forget();
    }

    protected override void ObjectDisable()
    {
        base.ObjectDisable();
    }

    #region 능력치

    protected virtual void InitStatValue()
    {
        if (m_IsDead)
        {
            return;
        }

        m_Exp = m_EnemyData.Exp;

        // 스텟 증가량 우선 계산
        var vitality = m_EnemyData.Vitality;
        var mentality = m_EnemyData.Mentality;
        var strength = m_EnemyData.Strength;
        var dexterity = m_EnemyData.Dexterity;
        var intelligence = m_EnemyData.Intelligence;

        var previousMaxHp = m_MaxHp;
        m_MaxHp = m_EnemyData.Health + Calculator.CalcStatToValue(EnemyEnum.EStatType.Vitality, EnemyEnum.EValueType.Health, vitality);
        if (previousMaxHp < m_MaxHp)
        {
            m_Hp += m_MaxHp - previousMaxHp;
        }
        m_HpRegen = Calculator.CalcStatToValue(EnemyEnum.EStatType.Health, EnemyEnum.EValueType.HpRegen, m_MaxHp);
        m_HpRegen += Calculator.CalcStatToValue(EnemyEnum.EStatType.Vitality, EnemyEnum.EValueType.HpRegen, vitality);

        m_MaxMp = m_EnemyData.Mana + Calculator.CalcStatToValue(EnemyEnum.EStatType.Mentality, EnemyEnum.EValueType.Mana, mentality);
        m_MpRegen = Calculator.CalcStatToValue(EnemyEnum.EStatType.Mana, EnemyEnum.EValueType.MpRegen, m_MaxMp);
        m_MpRegen += Calculator.CalcStatToValue(EnemyEnum.EStatType.Mentality, EnemyEnum.EValueType.HpRegen, mentality);
    }

    #endregion

    public async UniTask InitEnemy_UniTask(GameEnemyData enemyData, List<Vector3> wayPoints)
    {
        // 능력 계산
        m_EnemyData = enemyData;
        m_MaxHp = 0;
        InitStatValue();


        // 이미지 불러오기

        // 사이즈 조절?

        m_Hp = m_MaxHp;
        m_WayPoints = wayPoints;

        m_IsDead = false;
    }

    public async UniTask MoveEnemy_UniTask()
    {
        m_MoveIndex = 0;
        try
        {
            while (true)
            {
                if (ActiveCancellationToken.IsCancellationRequested)
                {
                    break;
                }

                var movePosition = m_WayPoints[m_MoveIndex];
                while (Vector3.Distance(transform.position, movePosition) <= MOVE_CHECK_DISTANCE)
                {
                    transform.position = Vector3.MoveTowards(transform.position, movePosition, m_CurrentEnemyData.MoveSpeed * Time.deltaTime);
                }

                m_MoveIndex++;
                if (m_MoveIndex == m_WayPoints.Count)
                {
                    break;
                }

                await UniTask.Yield(cancellationToken: ActiveCancellationToken.Token);
            }
        }
        catch (OperationCanceledException)
        {
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }
}
