using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioClipCollection", menuName = "Scriptable Objects/Collection/AudioClipCollection")]
public class AudioClipCollection : ScriptableObject
{
    public List<AudioClipData> BGM_AudioClipDatas;
    public List<AudioClipData> EffectUI_AudioClipDatas;
    public List<AudioClipData> EffectGame_AudioClipDatas;
}
