using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageData", menuName = "Scriptable Objects/Data/StageData")]
public class StageData : ScriptableObject
{
    public StageKeyData KeyData;
    public string VillageName;
    public string Description;
    public string ImageAddressableKey;
    public string MapAddressableKey;
    public float StageWaitTime;
    public float VillageHp;
    public List<WaveData> WaveDatas;
}
