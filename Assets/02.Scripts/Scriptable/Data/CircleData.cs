using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CircleData", menuName = "Scriptable Objects/Data/CircleData")]
public class CircleData : ScriptableObject
{
    public CharacterEnum.ECircleType CircleType;
    public List<CircleLevelData> CircleLevelDatas;
}
