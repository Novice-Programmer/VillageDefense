using UnityEngine;

[CreateAssetMenu(fileName = "데이터_캐릭터_", menuName = "Data/캐릭터", order = 1)]
public class SData_Character : SData
{
    public Enum_CharacterName CharacterName;
    public Data_BaseStat BaseStat;
    public Data_LevelStat LevelStat;
    public float Cost;
    public float LevelCost;
    public int MaxLevel;
    public Enum_CharacterRank MaxRank;
}
