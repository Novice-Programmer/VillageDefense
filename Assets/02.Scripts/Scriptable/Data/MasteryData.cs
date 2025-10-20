using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MasteryData", menuName = "Scriptable Objects/Data/MasteryData")]
public class MasteryData : ScriptableObject
{
    public CharacterHelper.EMasteryType MasteryType;
    public List<MasteryLevelData> MasteryLevelDatas;
}
