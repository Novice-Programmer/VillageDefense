using UnityEngine;

[CreateAssetMenu(fileName = "AudioClipData", menuName = "Scriptable Objects/Data/AudioClipData")]
public class AudioClipData : ScriptableObject
{
    public AudioClipKeyData KeyData;
    public float Volume = SoundHelper.DEFAULT_VOLUME;
    public string AudioClipAddressableKey;
}
