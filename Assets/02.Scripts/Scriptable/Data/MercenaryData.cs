using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MercenaryData", menuName = "Scriptable Objects/Data/MercenaryData")]
public class MercenaryData : ScriptableObject
{
    public CharacterEnum.EName Name;
    public CharacterEnum.ERank Rank;
    public int Level;

    public float Health;
    public float Mana;

    public float Vitality;
    public float Mentality;
    public float Strength;
    public float Dexterity;
    public float Intelligence;
    public float Luck;

    public List<MasteryKeyData> MasteryLevelKeyDatas;
    public List<CircleKeyData> CircleLevelKeyDatas;
}
