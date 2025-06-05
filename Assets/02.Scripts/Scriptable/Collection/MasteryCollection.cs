using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MasteryCollection", menuName = "Scriptable Objects/Collection/MasteryCollection")]
public class MasteryCollection : ScriptableObject
{
    public List<MasteryData> MasteryDatas;
}
