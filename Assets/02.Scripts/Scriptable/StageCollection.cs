using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageCollection", menuName = "Scriptable Objects/Collection/StageCollection")]
public class StageCollection : ScriptableObject
{
    public List<StageData> StageDatas;
}
