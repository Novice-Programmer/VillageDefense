using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/Data/EnemyData")]
public class EnemyData : ScriptableObject
{
    public EnemyKeyData KeyData;
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
}
