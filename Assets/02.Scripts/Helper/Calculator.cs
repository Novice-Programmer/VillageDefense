using NUnit.Framework.Internal;
using EStatType = EnemyEnum.EStatType;
using EValueType = EnemyEnum.EValueType;

public static class Calculator
{
    private static float HEALTH_TO_HPREGEN = 0.02f;
    private static float MANA_TO_MPREGEN = 0.05f;
    private static float VITALITY_TO_HEALTH = 1.4f;
    private static float VITALITY_TO_HPREGEN= 0.01f;
    private static float MENTALITY_TO_MANA = 0.8f;
    private static float MENTALITY_TO_MPREGEN = 0.01f;

    public static float CalcStatToValue(EStatType statType, EValueType valueType, float stat)
    {
        switch (statType)
        {
            case EStatType.Health:
                return valueType switch
                {
                    EValueType.HpRegen => stat * HEALTH_TO_HPREGEN,
                    _ => 0f
                };
            case EStatType.Mana:
                return valueType switch
                {
                    EValueType.MpRegen => stat * MANA_TO_MPREGEN,
                    _ => 0f
                };
            case EStatType.Vitality:
                return valueType switch
                {
                    EValueType.Health => stat * VITALITY_TO_HEALTH,
                    EValueType.HpRegen => stat * VITALITY_TO_HPREGEN,
                    _ => 0f
                };
            case EStatType.Mentality:
                return valueType switch
                {
                    EValueType.Mana => stat * MENTALITY_TO_MANA,
                    EValueType.MpRegen => stat * MENTALITY_TO_MPREGEN,
                    _ => 0f
                };
            case EStatType.Strength:
                return valueType switch
                {
                    _ => 0f
                };
            case EStatType.Dexterity:
                return valueType switch
                {
                    _ => 0f
                };
            case EStatType.Intelligence:
                return valueType switch
                {
                    _ => 0f
                };
        }

        return 0;
    }
}
