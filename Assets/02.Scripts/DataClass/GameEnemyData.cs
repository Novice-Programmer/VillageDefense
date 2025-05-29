public class GameEnemyData
{
    public EnemyEnum.EName Name;
    public EnemyEnum.ERank Rank;
    public int Level;
    public float Exp;

    public string ImageAddressableKey;
    public string ObjectAddressableKey;

    public float Health;
    public float Mana;

    public float Vitality;
    public float Mentality;
    public float Strength;
    public float Dexterity;
    public float Intelligence;

    public float PhysicalAttack;
    public float PhysicalDefense;

    public float MagicAttack;
    public float MagicDefense;

    public float AttackSpeed;
    public float MoveSpeed;

    public GameEnemyData()
    {
    }

    public GameEnemyData(EnemyData enemyData)
    {
        Name = enemyData.Name;
        Rank = enemyData.Rank;
        Level = enemyData.Level;
        Exp = enemyData.Exp;

        ImageAddressableKey = enemyData.ImageAddressableKey;
        ObjectAddressableKey = enemyData.ObjectAddressableKey;

        Health = enemyData.Health;
        Mana = enemyData.Mana;

        Vitality = enemyData.Vitality;
        Mentality = enemyData.Mentality;
        Strength = enemyData.Strength;
        Dexterity = enemyData.Dexterity;
        Intelligence = enemyData.Intelligence;

        PhysicalAttack = enemyData.PhysicalAttack;
        PhysicalDefense = enemyData.PhysicalDefense;

        MagicAttack = enemyData.MagicAttack;
        MagicDefense = enemyData.MagicDefense;

        AttackSpeed = enemyData.AttackSpeed;
        MoveSpeed = enemyData.MoveSpeed;
    }

    public GameEnemyData Copy()
    {
        return new()
        {
            Name = this.Name,
            Rank = this.Rank,
            Level = this.Level,
            Exp = this.Exp,

            ImageAddressableKey = this.ImageAddressableKey,
            ObjectAddressableKey = this.ObjectAddressableKey,

            Health = this.Health,
            Mana = this.Mana,

            Vitality = this.Vitality,
            Mentality = this.Mentality,
            Strength = this.Strength,
            Dexterity = this.Dexterity,
            Intelligence = this.Intelligence,

            PhysicalAttack = this.PhysicalAttack,
            PhysicalDefense = this.PhysicalDefense,

            MagicAttack = this.MagicAttack,
            MagicDefense = this.MagicDefense,

            AttackSpeed = this.AttackSpeed,
            MoveSpeed = this.MoveSpeed,
        };
    }
}