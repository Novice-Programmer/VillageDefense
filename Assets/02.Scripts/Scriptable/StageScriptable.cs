using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageScriptable", menuName = "Scriptable Objects/StageScriptable")]
public class StageScriptable : ScriptableObject
{
    public float StageWaitTime;
    public List<WaveData> WaveDatas;
}
