using System;
using System.Collections.Generic;

[Serializable]
public class WeaponLevelData
{
    public WeaponKeyData KeyData;
    public EquipmentEnum.EWeaponType WeaponType;
    public EquipmentEnum.ERank Rank;

    public string ImageAddressableKey;
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
