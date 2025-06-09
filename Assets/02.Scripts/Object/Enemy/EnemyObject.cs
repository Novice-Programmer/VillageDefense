using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using EnemyStatType = EnemyEnum.EStatType;
using EnemyValueType = EnemyEnum.EValueType;

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

    protected float m_FireAttack;
    protected float m_FireDefense;
    protected float m_FirePenetration;
    protected float m_FireReduction;

    protected float m_IceAttack;
    protected float m_IceDefense;
    protected float m_IcePenetration;
    protected float m_IceReduction;

    protected float m_LightningAttack;
    protected float m_LightningDefense;
    protected float m_LightningPenetration;
    protected float m_LightningReduction;

    protected float m_AttackSpeed;
    protected float m_MoveSpeed;

    private List<Vector3> m_WayPointPositions;

    protected const float MOVE_CHECK_DISTANCE = 0.05f;
    protected const float DEFAULT_ACCURACY = 0.7f;

    protected override void OnObjectActive()
    {
        base.OnObjectActive();
        MoveEnemy_UniTask().Forget();
    }

    protected override void OnObjectDisactive()
    {
        base.OnObjectDisactive();
    }

    #region 능력치

    protected virtual void InitStatValue()
    {
        if (m_IsDead)
        {
            return;
        }

        m_Exp = m_EnemyData.Exp;

        var previousMaxHp = m_MaxHp;
        m_MaxHp = m_EnemyData.Health + Calculator.CalcStatToValue(EnemyStatType.Vitality, EnemyValueType.Health, m_EnemyData.Vitality);
        if (previousMaxHp < m_MaxHp)
        {
            m_Hp += m_MaxHp - previousMaxHp;
        }
        m_HpRegen = Calculator.CalcStatToValue(EnemyStatType.Health, EnemyValueType.HpRegen, m_MaxHp);
        m_HpRegen += Calculator.CalcStatToValue(EnemyStatType.Vitality, EnemyValueType.HpRegen, m_EnemyData.Vitality);

        m_MaxMp = m_EnemyData.Mana + Calculator.CalcStatToValue(EnemyStatType.Mentality, EnemyValueType.Mana, m_EnemyData.Mentality);
        m_MpRegen = Calculator.CalcStatToValue(EnemyStatType.Mana, EnemyValueType.MpRegen, m_MaxMp);
        m_MpRegen += Calculator.CalcStatToValue(EnemyStatType.Mentality, EnemyValueType.HpRegen, m_EnemyData.Mentality);

        m_CriticalRate = Calculator.CalcStatToValue(EnemyStatType.Luck, EnemyValueType.CriticalRate, m_EnemyData.Luck);
        m_CriticalResistRate = Calculator.CalcStatToValue(EnemyStatType.Luck, EnemyValueType.CriticalResistRate, m_EnemyData.Luck);
        m_CriticalDamage = Calculator.CalcStatToValue(EnemyStatType.Dexterity, EnemyValueType.CriticalDamage, m_EnemyData.Dexterity);

        m_Accuracy = DEFAULT_ACCURACY + Calculator.CalcStatToValue(EnemyStatType.Dexterity, EnemyValueType.Accuracy, m_EnemyData.Dexterity);
        m_Evasion = Calculator.CalcStatToValue(EnemyStatType.Luck, EnemyValueType.Evasion, m_EnemyData.Luck);

        m_PhysicalAttack = m_EnemyData.PhysicalAttack + Calculator.CalcStatToValue(EnemyStatType.Strength, EnemyValueType.PhysicalAttack, m_EnemyData.Strength);
        m_PhysicalDefense = m_EnemyData.PhysicalDefense + Calculator.CalcStatToValue(EnemyStatType.Vitality, EnemyValueType.PhysicalDefense, m_EnemyData.Vitality);
        m_PhysicalPenetration = Calculator.CalcStatToValue(EnemyStatType.Strength, EnemyValueType.PhysicalPenetration, m_EnemyData.Strength);
        m_PhysicalReduction = Calculator.CalcStatToValue(EnemyStatType.Vitality, EnemyValueType.PhysicalReduction, m_EnemyData.Vitality);

        m_MagicAttack = m_EnemyData.MagicAttack + Calculator.CalcStatToValue(EnemyStatType.Strength, EnemyValueType.MagicAttack, m_EnemyData.Intelligence);
        m_MagicDefense = m_EnemyData.MagicDefense + Calculator.CalcStatToValue(EnemyStatType.Vitality, EnemyValueType.MagicDefense, m_EnemyData.Mentality);
        m_MagicPenetration = Calculator.CalcStatToValue(EnemyStatType.Strength, EnemyValueType.MagicPenetration, m_EnemyData.Intelligence);
        m_MagicReduction = Calculator.CalcStatToValue(EnemyStatType.Vitality, EnemyValueType.MagicReduction, m_EnemyData.Mentality);

        m_FireAttack = m_EnemyData.FireAttack;
        m_FireDefense = m_EnemyData.FireDefense;
        m_FirePenetration = m_EnemyData.FirePenetration;
        m_FireReduction = m_EnemyData.FireReduction;

        m_IceAttack = m_EnemyData.IceAttack;
        m_IceDefense = m_EnemyData.IceDefense;
        m_IcePenetration = m_EnemyData.IcePenetration;
        m_IceReduction = m_EnemyData.IceReduction;

        m_LightningAttack = m_EnemyData.LightningAttack;
        m_LightningDefense = m_EnemyData.LightningDefense;
        m_LightningPenetration = m_EnemyData.LightningPenetration;
        m_LightningReduction = m_EnemyData.LightningReduction;

        m_AttackSpeed = m_EnemyData.AttackSpeed;
        m_MoveSpeed = m_EnemyData.MoveSpeed;
    }

    #endregion

    public async UniTask InitEnemy_UniTask(GameEnemyData enemyData, WayPointData wayPointData)
    {
        // 능력 계산
        m_EnemyData = enemyData;
        InitStatValue();

        // 이미지 불러오기
        var imageSprite = await ObjectManager.Instance.LoadObject_UniTask<Sprite>(enemyData.ImageAddressableKey);
        Appearance.sprite = imageSprite;

        // 사이즈 조절?

        m_Hp = m_MaxHp;
        m_WayPointPositions = wayPointData.WayPointPositions;
        transform.position = wayPointData.StartPosition;

        m_IsDead = false;
    }

    public async UniTask MoveEnemy_UniTask()
    {
        var moveIndex = 0;
        var movePositions = m_WayPointPositions.Select(v => v).ToList();
        try
        {
            while (true)
            {
                if (m_ActiveCancellationToken.IsCancellationRequested)
                {
                    break;
                }

                var movePosition = movePositions[moveIndex];
                while (MOVE_CHECK_DISTANCE <= Vector3.Distance(transform.position, movePosition))
                {
                    transform.position = Vector3.MoveTowards(transform.position, movePosition, m_MoveSpeed * Time.deltaTime);
                    await UniTask.Yield(cancellationToken: m_ActiveCancellationToken.Token);
                }

                moveIndex++;
                if (moveIndex == movePositions.Count)
                {
                    break;
                }

                await UniTask.Yield(cancellationToken: m_ActiveCancellationToken.Token);
            }
        }
        catch (OperationCanceledException)
        {
        }
    }
}
