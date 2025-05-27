using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/Data/EnemyData")]
public class EnemyData : ScriptableObject
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
}
