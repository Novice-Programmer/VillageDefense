public class GameMasteryLevelData
{
    public CharacterHelper.EMasteryType MasteryType;
    public int Level;
    public float CriticalRate;
    public float CriticalDamage;
    public float Accuracy;
    public float PhysicalAttack;
    public float PhysicalPenetration;
    public float AttackSpeed;

    public GameMasteryLevelData()
    {

    }

    public GameMasteryLevelData(MasteryLevelData masteryLevelData)
    {
        MasteryType = masteryLevelData.KeyData.MasteryType;
        Level = masteryLevelData.KeyData.Level;
        CriticalRate = masteryLevelData.CriticalRate;
        CriticalDamage = masteryLevelData.CriticalDamage;
        Accuracy = masteryLevelData.Accuracy;
        PhysicalAttack = masteryLevelData.PhysicalAttack;
        PhysicalPenetration = masteryLevelData.PhysicalPenetration;
        AttackSpeed = masteryLevelData.AttackSpeed;
    }
}
