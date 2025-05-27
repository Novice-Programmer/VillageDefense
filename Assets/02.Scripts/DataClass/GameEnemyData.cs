public class GameEnemyData
{
    public EnemyEnum.EName Name;
    public EnemyEnum.ERank Rank;
    public int Level;

    public string ImageAddressableKey;

    public float Health;
    public float HealthRegen;

    public float AttackSpeed;

    public float PhysicalAttack;
    public float PhysicalPenetration;
    public float PhysicalDefense;
    public float PhysicalReduction;

    public float MagicAttack;
    public float MagicPenetration;
    public float MagicDefense;
    public float MagicReduction;

    public float Speed;
    public float Exp;

    public GameEnemyData()
    {

    }

    public GameEnemyData(EnemyData enemyData)
    {
        Name = enemyData.Name;
        Rank = enemyData.Rank;
        Level = enemyData.Level;

        ImageAddressableKey = enemyData.ImageAddressableKey;

        Health = enemyData.Health;
        HealthRegen = enemyData.HealthRegen;

        AttackSpeed = enemyData.AttackSpeed;

        PhysicalAttack = enemyData.PhysicalAttack;
        PhysicalPenetration = enemyData.PhysicalPenetration;
        PhysicalDefense = enemyData.PhysicalDefense;
        PhysicalReduction = enemyData.PhysicalReduction;

        MagicAttack = enemyData.MagicAttack;
        MagicPenetration = enemyData.MagicPenetration;
        MagicDefense = enemyData.MagicDefense;
        MagicReduction = enemyData.MagicReduction;

        Speed = enemyData.Speed;
        Exp = enemyData.Exp;
    }

    public GameEnemyData Copy()
    {
        return new()
        {
            Name = this.Name,
            Rank = this.Rank,
            Level = this.Level,

            ImageAddressableKey = this.ImageAddressableKey,

            Health = this.Health,
            HealthRegen = this.HealthRegen,

            AttackSpeed = this.AttackSpeed,

            PhysicalAttack = this.PhysicalAttack,
            PhysicalPenetration = this.PhysicalPenetration,
            PhysicalDefense = this.PhysicalDefense,
            PhysicalReduction = this.PhysicalReduction,

            MagicAttack = this.MagicAttack,
            MagicPenetration = this.MagicPenetration,
            MagicDefense = this.MagicDefense,
            MagicReduction = this.MagicReduction,

            Speed = this.Speed,
            Exp = this.Exp,
        };
    }
}