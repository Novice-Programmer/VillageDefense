using NUnit.Framework.Internal;
using EStatType = EnemyEnum.EStatType;
using EValueType = EnemyEnum.EValueType;

public static class Calculator
{
    private const float HEALTH_TO_HPREGEN = 0.02f;
    private const float MANA_TO_MP_REGEN = 0.05f;
    private const float VITALITY_TO_HEALTH = 1.4f;
    private const float VITALITY_TO_HP_REGEN = 0.01f;
    private const float VITALITY_TO_PHYSICAL_DEFENSE = 0.12f;
    private const float VITALITY_TO_PHYSICAL_REDUCTION = 0.004f;
    private const float MENTALITY_TO_MANA = 0.8f;
    private const float MENTALITY_TO_MP_REGEN = 0.01f;
    private const float MENTALITY_TO_MAGIC_DEFENSE = 0.1f;
    private const float MENTALITY_TO_MAGIC_REDUCTION = 0.0031f;
    private const float STRENGTH_TO_PHYSICAL_ATTACK = 1.1f;
    private const float STRENGTH_TO_PHYSICAL_PENETRATION = 0.011f;
    private const float DEXTERITY_TO_CRITICAL_DAMAGE = 0.02f;
    private const float DEXTERITY_TO_ACCURACY = 0.01f;
    private const float INTELLIGENCE_TO_MAGIC_ATTACK = 0.9f;
    private const float INTELLIGENCE_TO_MAGIC_PENETRATION = 0.011f;
    private const float LUCK_TO_CRITICAL_RATE = 0.012f;
    private const float LUCK_TO_CRITICAL_RESIST_RATE = 0.005f;
    private const float LUCK_TO_EVASION = 0.006f;

    public static float CalcStatToValue(EStatType statType, EValueType valueType, float stat)
    {
        return statType switch
        {
            EStatType.Health => valueType switch
            {
                EValueType.HpRegen => stat * HEALTH_TO_HPREGEN,
                _ => 0f
            },

            EStatType.Mana => valueType switch
            {
                EValueType.MpRegen => stat * MANA_TO_MP_REGEN,
                _ => 0f
            },

            EStatType.Vitality => valueType switch
            {
                EValueType.Health => stat * VITALITY_TO_HEALTH,
                EValueType.HpRegen => stat * VITALITY_TO_HP_REGEN,
                EValueType.PhysicalDefense => stat * VITALITY_TO_PHYSICAL_DEFENSE,
                EValueType.PhysicalReduction => stat * VITALITY_TO_PHYSICAL_REDUCTION,
                _ => 0f
            },

            EStatType.Mentality => valueType switch
            {
                EValueType.Mana => stat * MENTALITY_TO_MANA,
                EValueType.MpRegen => stat * MENTALITY_TO_MP_REGEN,
                EValueType.MagicDefense => stat * MENTALITY_TO_MAGIC_DEFENSE,
                EValueType.MagicReduction => stat * MENTALITY_TO_MAGIC_REDUCTION,
                _ => 0f
            },

            EStatType.Strength => valueType switch
            {
                EValueType.PhysicalAttack => stat * STRENGTH_TO_PHYSICAL_ATTACK,
                EValueType.PhysicalPenetration => stat * STRENGTH_TO_PHYSICAL_PENETRATION,
                _ => 0f
            },

            EStatType.Dexterity => valueType switch
            {
                EValueType.CriticalDamage => stat * DEXTERITY_TO_CRITICAL_DAMAGE,
                EValueType.Accuracy => stat * DEXTERITY_TO_ACCURACY,
                _ => 0f
            },

            EStatType.Intelligence => valueType switch
            {
                EValueType.MagicAttack => stat * INTELLIGENCE_TO_MAGIC_ATTACK,
                EValueType.MagicPenetration => stat * INTELLIGENCE_TO_MAGIC_PENETRATION,
                _ => 0f
            },

            EStatType.Luck => valueType switch
            {
                EValueType.CriticalRate => stat * LUCK_TO_CRITICAL_RATE,
                EValueType.CriticalResistRate => stat * LUCK_TO_CRITICAL_RESIST_RATE,
                EValueType.Evasion => stat * LUCK_TO_EVASION,
                _ => 0f
            },

            _ => 0,
        };
    }
}
