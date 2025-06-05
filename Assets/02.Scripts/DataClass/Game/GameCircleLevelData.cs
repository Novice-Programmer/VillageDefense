public class GameCircleLevelData
{
    public CharacterEnum.ECircleType CircleType;
    public int Level;
    public float CriticalRate;
    public float CriticalDamage;
    public float Accuracy;
    public float MagicAttack;
    public float MagicPenetration;
    public float FireAttack;
    public float FirePenetration;
    public float IceAttack;
    public float IcePenetration;
    public float LightningAttack;
    public float LightningPenetration;
    public float AttackSpeed;

    public GameCircleLevelData()
    {

    }

    public GameCircleLevelData(CircleLevelData circleLevelData)
    {
        CircleType = circleLevelData.KeyData.CircleType;
        Level = circleLevelData.KeyData.Level;
        CriticalRate = circleLevelData.CriticalRate;
        CriticalDamage = circleLevelData.CriticalDamage;
        Accuracy = circleLevelData.Accuracy;
        MagicAttack = circleLevelData.MagicAttack;
        MagicPenetration = circleLevelData.MagicPenetration;
        FireAttack = circleLevelData.FireAttack;
        FirePenetration = circleLevelData.FirePenetration;
        IceAttack = circleLevelData.IceAttack;
        IcePenetration = circleLevelData.IcePenetration;
        LightningAttack = circleLevelData.LightningAttack;
        LightningPenetration = circleLevelData.LightningPenetration;
        AttackSpeed = circleLevelData.AttackSpeed;
    }
}
