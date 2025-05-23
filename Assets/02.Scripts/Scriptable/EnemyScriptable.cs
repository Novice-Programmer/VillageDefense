using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptable", menuName = "Scriptable Objects/EnemyScriptable")]
public class EnemyScriptable : ScriptableObject
{
    public EnemyEnum.EName Name;
    public EnemyEnum.ERank Rank;
    public int Level;

    public Sprite Appearance;

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
