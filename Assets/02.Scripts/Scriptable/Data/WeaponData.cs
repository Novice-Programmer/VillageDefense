using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponData", menuName = "Scriptable Objects/Data/WeaponData")]
public class WeaponData : ScriptableObject
{
    public WeaponKeyData KeyData;
    public WeaponEnum.EWeaponType WeaponType;
    public WeaponEnum.ERank Rank;

    public string LeftHandWeaponAddressableKey;
    public string RightHandWeaponAddressableKey;

    public float CriticalRate;
    public float CriticalDamage;

    public float PhysicalAttack;
    public float PhysicalPenetration;

    public float MagicAttack;
    public float MagicPenetration;

    public float FireAttack;
    public float FirePenetration;

    public float IceAttack;
    public float IcePenetration;

    public float LightningAttack;
    public float LightningPenetration;

    public float AttackSpeed;

    public List<SkillKeyData> SkillKeyDatas;
}
