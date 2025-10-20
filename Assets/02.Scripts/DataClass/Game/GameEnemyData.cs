public class GameEnemyData
{
    public EnemyHelper.EName Name;
    public EnemyHelper.ERank Rank;
    public int Level;
    public float Exp;
    public float VillageDamage;

    public string ImageAddressableKey;
    public string ObjectAddressableKey;

    public float Health;
    public float Mana;

    public float Vitality;
    public float Mentality;
    public float Strength;
    public float Dexterity;
    public float Intelligence;
    public float Luck;

    public float PhysicalAttack;
    public float PhysicalDefense;

    public float MagicAttack;
    public float MagicDefense;

    public float FireAttack;
    public float FireDefense;
    public float FirePenetration;
    public float FireReduction;

    public float IceAttack;
    public float IceDefense;
    public float IcePenetration;
    public float IceReduction;

    public float LightningAttack;
    public float LightningDefense;
    public float LightningPenetration;
    public float LightningReduction;

    public float AttackSpeed;
    public float MoveSpeed;

    public GameEnemyData()
    {
    }

    public GameEnemyData(EnemyData enemyData)
    {
        Name = enemyData.KeyData.Name;
        Rank = enemyData.KeyData.Rank;
        Level = enemyData.KeyData.Level;
        Exp = enemyData.Exp;
        VillageDamage = enemyData.VillageDamage;

        ImageAddressableKey = enemyData.ImageAddressableKey;
        ObjectAddressableKey = enemyData.ObjectAddressableKey;

        Health = enemyData.Health;
        Mana = enemyData.Mana;

        Vitality = enemyData.Vitality;
        Mentality = enemyData.Mentality;
        Strength = enemyData.Strength;
        Dexterity = enemyData.Dexterity;
        Intelligence = enemyData.Intelligence;
        Luck = enemyData.Luck;

        PhysicalAttack = enemyData.PhysicalAttack;
        PhysicalDefense = enemyData.PhysicalDefense;

        MagicAttack = enemyData.MagicAttack;
        MagicDefense = enemyData.MagicDefense;

        FireAttack = enemyData.FireAttack;
        FireDefense = enemyData.FireDefense;
        FirePenetration = enemyData.FirePenetration;
        FireReduction = enemyData.FireReduction;

        IceAttack = enemyData.IceAttack;
        IceDefense = enemyData.IceDefense;
        IcePenetration = enemyData.IcePenetration;
        IceReduction = enemyData.IceReduction;

        LightningAttack = enemyData.LightningAttack;
        LightningDefense = enemyData.LightningDefense;
        LightningPenetration = enemyData.LightningPenetration;
        LightningReduction = enemyData.LightningReduction;

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
            VillageDamage = this.VillageDamage,

            ImageAddressableKey = this.ImageAddressableKey,
            ObjectAddressableKey = this.ObjectAddressableKey,

            Health = this.Health,
            Mana = this.Mana,

            Vitality = this.Vitality,
            Mentality = this.Mentality,
            Strength = this.Strength,
            Dexterity = this.Dexterity,
            Intelligence = this.Intelligence,
            Luck = this.Luck,

            PhysicalAttack = this.PhysicalAttack,
            PhysicalDefense = this.PhysicalDefense,

            MagicAttack = this.MagicAttack,
            MagicDefense = this.MagicDefense,

            FireAttack = this.FireAttack,
            FireDefense = this.FireDefense,
            FirePenetration = this.FirePenetration,
            FireReduction = this.FireReduction,

            IceAttack = this.IceAttack,
            IceDefense = this.IceDefense,
            IcePenetration = this.IcePenetration,
            IceReduction = this.IceReduction,

            LightningAttack = this.LightningAttack,
            LightningDefense = this.LightningDefense,
            LightningPenetration = this.LightningPenetration,
            LightningReduction = this.LightningReduction,

            AttackSpeed = this.AttackSpeed,
            MoveSpeed = this.MoveSpeed,
        };
    }
}