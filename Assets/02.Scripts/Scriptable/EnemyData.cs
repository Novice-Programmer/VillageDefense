using UnityEngine;

[CreateAssetMenu(fileName = "EnemyData", menuName = "Scriptable Objects/Data/EnemyData")]
public class EnemyData : ScriptableObject
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
    public float Luck;

    public float PhysicalAttack;
    public float PhysicalDefense;

    public float MagicAttack;
    public float MagicDefense;

    public float AttackSpeed;
    public float MoveSpeed;
}
